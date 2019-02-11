using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;


/*
 * bitmapProto: bitclean/image.cs
 * Author: Austin Herman
 * 2/11/2019
 */

namespace bitmapproto
{
    class imageops
    {
		public imageops(Bitmap bmp)
		{
			imgdata.height = bmp.Height;
			imgdata.width = bmp.Width;
			imgdata.totalpixels = bmp.Height * bmp.Width;
		}

		public pixel[] getpixels()
        {
            return pixels;
        }

		public Bitmap parseImage(Bitmap bmp)
		{
			//string csvheader = "x, int";
			//StreamWriter csv = new StreamWriter(Path.GetDirectoryName(bmppath) + "\\" + Path.GetFileNameWithoutExtension(bmppath) + ".csv");

			//csv.WriteLine(csvheader);

			// Loop through the images pixels to reset color.
			int i = 0;
			pixels = new pixel[bmp.Width * bmp.Height];

			for (int y = 0; y < bmp.Height; y++)
			{
				for (int x = 0; x < bmp.Width; x++)
				{
					Color p = bmp.GetPixel(x, y);

					if (p == constants.FLOOR)
						bmp.SetPixel(x, y, constants.WHITE);

					pixels[i].id = i;
					pixels[i].value = coltoi(p);
					pixels[i].selected = false;
					pixels[i].found = false;

					i++;
					//Console.WriteLine(coltoi(bmp.GetPixel(x, y)));
					//csv.WriteLine(x + "," + coltoi(bmp.GetPixel(x, y)));
				}
			}

			Console.Write("bmp size: %i last id: %i", imgdata.totalpixels, i);

			//csv.Close();

			return bmp;
		}

		public short coltoi(Color p)
		{
			short numcolor = 0;
			int greenShift = 510;

			if (p == constants.FLOOR)
				numcolor = constants.WHITE_COL_VAL;
			else if (p.R == 255)
				numcolor = (short) (p.R + (255 - p.G) + p.B + greenShift);
			else if (p.G == 255)
				numcolor = (short) (p.R + p.G + (255 - p.B));
			else
				numcolor = (short) (p.R + p.G + p.B - 255);

			return numcolor;
		}

		public ref data getImageData()
        {
            return ref imgdata;
        }

        private data imgdata;
        private pixel[] pixels;
        private readonly string image_err = "::IMAGE::error : ";
    }
}