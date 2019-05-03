using System.Drawing;

/*
 * bitclean: /bitclean/ImageOperations.cs
 * author: Austin Herman
 * 2/11/2019
 * holds basic routines for various operations on the displayed image
 */

namespace BitClean
{
    public static class ImageOperations
    {
		// changes Magenta floor colored pixels from Cloud Compare into white
		public static Bitmap ParseImage(Bitmap bmp, ref Pixel[] pixels)
		{
			int i = 0;
			pixels = new Pixel[bmp.Width * bmp.Height];

			for (int y = 0; y < bmp.Height; y++)
			{
				for (int x = 0; x < bmp.Width; x++)
				{
					Color p = bmp.GetPixel(x, y);

					// if the current pixel is the FLOOR (magenta) color, set it to white
					if (p == Constants.FLOOR) {
						bmp.SetPixel(x, y, Constants.WHITE);
						p = bmp.GetPixel(x, y);
					}
                    /*pixels[i] = new Pixel
                    {
                        // store pixel info
                        id = i,
                        value = ColToInt(p),
                        r = p.R,
                        g = p.G,
                        b = p.B,
                        selected = false
                    };*/

                    pixels[i].id = i;
                    pixels[i].value = ColToInt(p);
                    pixels[i].r = p.R;
                    pixels[i].g = p.G;
                    pixels[i].b = p.B;
                    pixels[i].selected = false;

                    // System.Console.WriteLine("int:{0} - r:{1}, g:{2}, b:{3} at ({4},{5})", pixels[i].value, pixels[i].r, pixels[i].g, pixels[i].b, x, y);

                    i++;
				}
			}

			return bmp;
		}

		public static void PushPixelsToImage(Bitmap bmp, Pixel[] pixels)
		{
			// update bmp with pixels stored in pixel array
			int i = 0;
			for (int y = 0; y < bmp.Height; y++) {
				for (int x = 0; x < bmp.Width; x++) {
					Color toargb = Color.FromArgb(pixels[i].r, pixels[i].g, pixels[i].b);
					bmp.SetPixel(x, y, toargb);
					i++;
				}
			}
		}

		public static short ColToInt(Color p)
		{
            // convert the pixel color from (R,G,B) to a short
            // scales as [(0,0,255) = 1] -> [(255,0,0) = 1021]
            /*
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
			*/

            short numcolor = 0;

            if (p == Constants.WHITE)
                numcolor = Constants.INT_WHITE;
            else if (p == Constants.OBJ_TAG)
                numcolor = Constants.INT_OBJ_TAG;
            else if (p.R == 255)
                numcolor = (short)(255 + (255 - p.G) + 255 + 1);
            else if (p.B == 0)
                numcolor = (short)(p.R + 255 + 1);
            else
                numcolor = (short)((255 - p.B) + 1);

            return numcolor;
        }
    }
}