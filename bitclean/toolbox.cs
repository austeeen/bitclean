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
    public class Toolbox
    {
        public Toolbox(Pixel[] p, Data dat)
        {
            pixels = p;
			imgdata = dat;
        }

        //the big boy, iterates through the pixels and drives algorithms
        public void Run()
        {
            if (pixels == null)
            {
                MessageBox.Show("No Pixels Loaded", "no pixels", 0);
                return;
            }

            Selection s = new Selection(pixels, imgdata.width, imgdata.totalpixels);
			int tagCount = 0;
            for (int i = 0; i < imgdata.totalpixels; i++)
            {
                if (s.Get(i)) // get the next object
                {
                    buffer = s.Buffer;
                    perimeter = s.Perimeter;

					ObjectData dat = new ObjectData {
						tag = tagCount,
						avghue = GetAverageHue(),
						density = GetValueDensity(),
						size = buffer.Count,
						edgeratio = buffer.Count / s.Edges,
						bounds = s.ObjBounds,
						position = new Coordinate {
							x = buffer[0] % imgdata.width,
							y = buffer[0] / imgdata.width
						}
					};

					tagCount++;

					Confidence c = new Confidence {
						isStructure = false
					};

					dat.objconf = c;

					objdat.Add(dat);

					//ColorBuffer(Constants.FLOOR);
                }
                s.ClearBuffer();
                buffer.Clear();
            }

			// find neighbors for each object
			// calculate confidence
        }

		//sets the buffer to be colored with color 'c'
		private void ColorBuffer(Color c)
		{
			for (int i = 0; i < buffer.Count; i++)
			{
				pixels[buffer[i]].value = ImageOps.ColToInt(c);
				pixels[buffer[i]].r = c.R;
				pixels[buffer[i]].g = c.G;
				pixels[buffer[i]].b = c.B;
			}
		}

		//sets the edges to be colored with color 'c'
		private void ColorEdges(Color c)
        {
			for (int i = 0; i < perimeter.Count; i++)
			{
				pixels[perimeter[i]].r = c.R;
				pixels[perimeter[i]].g = c.G;
				pixels[perimeter[i]].b = c.B;
			}
		}

		// calculates average hue or color of the buffer
        private double GetAverageHue()
        {
            double avg = 0;
			for (int i = 0; i < buffer.Count; i++)
				if (pixels[buffer[i]].value != Constants.INT_WHITE) avg += pixels[buffer[i]].value;
			return avg / buffer.Count;
        }

		// returns the percentage of non-white pixels in the buffer
		private double GetValueDensity()
		{
			double avg = 0;
			for (int i = 0; i < buffer.Count; i++)
				if (pixels[buffer[i]].value != Constants.INT_WHITE) avg++;
			return avg / buffer.Count * 100;
		}

		public List<ObjectData> GetObjectData()
        {
            return objdat;
        }

        private Pixel[] pixels = null;

		private readonly Data imgdata;

        private List<int> buffer = new List<int>();
        private List<int> perimeter = new List<int>();
        private List<ObjectData> objdat = new List<ObjectData>();
    }
}
