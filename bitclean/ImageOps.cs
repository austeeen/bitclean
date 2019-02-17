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

		// changes Magenta floor colored pixels from Cloud Compare into white
		public Bitmap parseImage(Bitmap bmp)
		{
			int i = 0;
			pixels = new pixel[bmp.Width * bmp.Height];

			for (int y = 0; y < bmp.Height; y++)
			{
				for (int x = 0; x < bmp.Width; x++)
				{
					Color p = bmp.GetPixel(x, y);

					if (p == constants.FLOOR) {
						bmp.SetPixel(x, y, constants.WHITE);
						p = bmp.GetPixel(x, y);
					}

					pixels[i].id = i;
					pixels[i].value = coltoi(p);
					pixels[i].r = p.R;
					pixels[i].g = p.G;
					pixels[i].b = p.B;
					pixels[i].selected = false;
					pixels[i].found = false;

					i++;
				}
			}

			return bmp;
		}

		public void pushpixelstoimage(Bitmap bmp)
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

		public void exportdiagnostics(Bitmap bmp, string bmppath, DIAGNOSTICS userchoice)
		{
			using (var saveFD = new SaveFileDialog())
			{
				saveFD.Title = "Save the diagostics csv file";
				saveFD.Filter = "csv files (*.csv)|*.csv";

				saveFD.FileName = Path.GetFileNameWithoutExtension(bmppath + "data");
				saveFD.InitialDirectory = Path.GetDirectoryName(bmppath);

				DialogResult result = saveFD.ShowDialog();

				if (result == DialogResult.OK)
				{
					switch(userchoice)
					{
						case DIAGNOSTICS.ALL:		{ exportAllDiagnostics(bmp, saveFD.FileName); break; }
						case DIAGNOSTICS.NON_WHITE: { exportAllDiagnostics(bmp, saveFD.FileName); break; }
					}
				}
			}
		}
		
		private void exportAllDiagnostics(Bitmap bmp, string path)
		{
			try
			{
				StreamWriter csv = new StreamWriter(path);
				csv.WriteLine("index, bmp_color_value, pixel_array_value");

				int i = 0;
				for (int y = 0; y < bmp.Height; y++)
				{
					for (int x = 0; x < bmp.Width; x++)
					{
						csv.WriteLine(i + "," + coltoi(bmp.GetPixel(x, y)) + "," + pixels[i].value);
						i++;
					}
				}

				csv.Close();
			}
			catch (Exception)
			{ }
		}

		private void exportNonWhiteDiagnostics(Bitmap bmp, string path)
		{
			try
			{
				StreamWriter csv = new StreamWriter(path);
				csv.WriteLine("index, bmp_color_value, pixel_array_value");

				int i = 0;
				for (int y = 0; y < bmp.Height; y++)
				{
					for (int x = 0; x < bmp.Width; x++)
					{
						if (coltoi(bmp.GetPixel(x, y)) != constants.INT_WHITE)
							csv.WriteLine(i + "," + coltoi(bmp.GetPixel(x, y)) + "," + pixels[i].value);

						i++;
					}
				}

				csv.Close();
			}
			catch (Exception)
			{ }
		}

		public static short coltoi(Color p)
		{
			short numcolor = 0;

			if (p == constants.WHITE)
				numcolor = constants.INT_WHITE;

			//want to offset everything by 1, so color integer values run [1 -> 1021]
			else if (p.R == 255)
				numcolor = (short) (p.R + (255 - p.G) + p.B + constants.GREEN_SHIFT + 1);
			else if (p.G == 255)
				numcolor = (short) (p.R + p.G + (255 - p.B) + 1);
			else
				numcolor = (short) (p.R + p.G + p.B + 1);

			// if last line was written as:
			// numcolor = (short) (p.R + p.G + p.B - 255 + 1);
			// any color with green and red < 255 would result in 0...?

			return numcolor;
		}

		public ref data getimagedata()
        {
            return ref imgdata;
        }

		public pixel[] getpixels()
		{
			return pixels;
		}

		private data imgdata;
        private pixel[] pixels = null;
        private readonly string image_err = "::IMAGE::error : ";
    }
}