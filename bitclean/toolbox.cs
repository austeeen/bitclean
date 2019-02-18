using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

/*
 * bitmapProto: BitClean/toolbox.cs
 * Author: Austin Herman
 * 2/11/2019
 */

namespace BitClean
{
    public class toolbox
    {
        public toolbox(pixel[] p, data dat)
        {
            pixels = p;
			imgdata = dat;
        }

        //the big boy, iterates through the pixels and drives algorithms
        public void run()
        {
            if (pixels == null)
            {
                MessageBox.Show("No Pixels Loaded", "no pixels", 0);
                return;
            }

            selection s = new selection(pixels, imgdata.width, imgdata.totalpixels);
            for (int i = 0; i < imgdata.totalpixels; i++)
            {
                if (s.get(i)) // get the next object
                {
                    buffer = s.Buffer;
                    perimeter = s.Perimeter;
					/*
					objectData dat = new objectData(getAverageValue(), buffer.Count, buffer.Count / s.getedges());
                    conf c = confidence.getconfidence(dat);
                    dat.objconf = c;
                    objdat.Add(dat);

                    if (!c.isStructure)
                        colorbuffer(constants.COLOR_CLEAR);
					*/
					colorbuffer(constants.FLOOR);
                }
                s.clearbuffer();
                buffer.Clear();
            }
        }

		//sets the buffer to be colored with color 'c'
		private void colorbuffer(Color c)
		{
			for (int i = 0; i < buffer.Count; i++)
			{
				pixels[buffer[i]].value = imageops.coltoi(c);
				pixels[buffer[i]].r = c.R;
				pixels[buffer[i]].g = c.G;
				pixels[buffer[i]].b = c.B;
			}
		}

		//sets the edges to be colored with color 'c'
		private void coloredges(Color c)
        {
			for (int i = 0; i < perimeter.Count; i++)
			{
				pixels[perimeter[i]].r = c.R;
				pixels[perimeter[i]].g = c.G;
				pixels[perimeter[i]].b = c.B;
			}
		}

		// calculates average hue or color of the buffer
        private double getAverageHue()
        {
            double avg = 0;
			for (int i = 0; i < buffer.Count; i++)
				avg += pixels[buffer[i]].value;
			return avg / buffer.Count;
        }

		// returns the percentage of non-white pixels in the buffer
		private double getValueDensity()
		{
			double avg = 0;
			for (int i = 0; i < buffer.Count; i++)
				if (pixels[buffer[i]].value != 0) avg++;
			return avg / buffer.Count;
		}

		public List<objectData> getObjectData()
        {
            return objdat;
        }

        private pixel[] pixels = null;

		private readonly data imgdata;

        private List<int> buffer = new List<int>();
        private List<int> perimeter = new List<int>();
        private List<objectData> objdat = new List<objectData>();
    }
}
