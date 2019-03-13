using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

/*
 * bitmapProto: BitClean/image.cs
 * Author: Austin Herman
 * 2/11/2019
 */

namespace BitClean
{
    public class ImageOps
    {
		private Data imgdata;
		public string imgpath;
		private Pixel[] pixels = null;

		public ImageOps(Bitmap bmp, string bmppath)
		{
			imgdata.height = bmp.Height;
			imgdata.width = bmp.Width;
			imgdata.totalpixels = bmp.Height * bmp.Width;
			imgpath = bmppath;
		}

		// changes Magenta floor colored pixels from Cloud Compare into white
		public Bitmap ParseImage(Bitmap bmp)
		{
			int i = 0;
			pixels = new Pixel[bmp.Width * bmp.Height];

			for (int y = 0; y < bmp.Height; y++)
			{
				for (int x = 0; x < bmp.Width; x++)
				{
					Color p = bmp.GetPixel(x, y);

					if (p == Constants.FLOOR) {
						bmp.SetPixel(x, y, Constants.WHITE);
						p = bmp.GetPixel(x, y);
					}

					pixels[i].id = i;
					pixels[i].value = ColToInt(p);
					pixels[i].r = p.R;
					pixels[i].g = p.G;
					pixels[i].b = p.B;
					pixels[i].selected = false;

					i++;
				}
			}

			return bmp;
		}

		public void PushPixelsToImage(Bitmap bmp)
		{
			int i = 0;

			for (int y = 0; y < bmp.Height; y++)
			{
				for (int x = 0; x < bmp.Width; x++)
				{
					Color toargb = Color.FromArgb(pixels[i].r, pixels[i].g, pixels[i].b);
					bmp.SetPixel(x, y, toargb);
					i++;
				}
			}
		}

		public static short ColToInt(Color p)
		{
			short numcolor = 0;

			if (p == Constants.WHITE)
				numcolor = Constants.INT_WHITE;
			else if (p == Constants.OBJ_TAG)
				numcolor = Constants.INT_OBJ_TAG;
			else if (p.R == 255)
				numcolor = (short)(p.R + (255 - p.G) + 510 + 1);
			else if (p.G == 255)
				numcolor = (short)(p.R + p.G + 255 + 1);
			else
				numcolor = (short)(p.G + (255 - p.B) + 1);

			return numcolor;
		}

		public string GetImagePath()
		{
			return imgpath;
		}

		public ref Data GetImageData()
        {
            return ref imgdata;
        }

		public Pixel[] GetPixels()
		{
			return pixels;
		}

    }
}