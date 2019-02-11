using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * bitmapProto: bitclean/toolbox.cs
 * Author: Austin Herman
 * 2/11/2019
 */

namespace bitmapproto
{
    public class toolbox
    {
        public toolbox(pixel[] p, int width, int height, int total)
        {
            pixels = p;
            imageWidth = width;
            totalPixels = total;
            imageHeight = height;
            brushMin = - (constants.BRUSH_SIZE / 2 - 1);
            brushMax = constants.BRUSH_SIZE / 2;
        }

        //the big boy, iterates through the pixels and drives algorithms
        public void run(ProgressBar progressBar1)
        {
            if (pixels == null)
            {
                MessageBox.Show("No Pixels Loaded", "no pixels", 0);
                return;
            }

            selection s = new selection(pixels, imageWidth, totalPixels);
            for (int i = 0; i < totalPixels; i++)
            {
                progressBar1.Value = i;

                if (s.get(i))
                {
                    buffer = s.Buffer;
                    perimeter = s.Perimeter;
                    objectData dat = new objectData(getAverageValue(), buffer.Count, buffer.Count / s.getedges());
                    conf c = confidence.getconfidence(dat);
                    dat.objconf = c;
                    objdat.Add(dat);

                    if (!c.isStructure)
                        colorbuffer(constants.COLOR_CLEAR);

                }
                s.clearbuffer();
                buffer.Clear();
            }
        }

        //colors a selection of pixels
        private void colorbuffer(int color)
        {
            for (int i = 0; i < buffer.Count; i++)
                pixels[buffer[i]].value = Convert.ToByte(color);
        }

        //colors the edges of a selection of pixels
        private void coloredges(int color)
        {
            for (int i = 0; i < perimeter.Count; i++)
                pixels[perimeter[i]].value = Convert.ToByte(color);
        }

        private double getAverageValue()
        {
            double avg = 0;
            for (int i = 0; i < buffer.Count; i++)
                avg += pixels[buffer[i]].value;
            return avg / buffer.Count;
        }

        public List<objectData> getObjectData()
        {
            return objdat;
        }

        private pixel[] pixels = null;
        private readonly int imageWidth, totalPixels, imageHeight, brushMin, brushMax;
        private List<int> buffer = new List<int>();
        private List<int> perimeter = new List<int>();
        private List<objectData> objdat = new List<objectData>();
    }
}
