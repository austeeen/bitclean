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
    public class imageops
    {
		public imageops(Bitmap bmp, string bmppath)
		{
			imgdata.height = bmp.Height;
			imgdata.width = bmp.Width;
			imgdata.totalpixels = bmp.Height * bmp.Width;
			imgpath = bmppath;
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

		public void exportdiagnostics(string header, diagnosticsProperties prop)
		{
			using (var saveFD = new SaveFileDialog())
			{
				saveFD.Title = "Save the diagostics csv file";
				saveFD.Filter = "csv files (*.csv)|*.csv";

				saveFD.FileName = Path.GetFileNameWithoutExtension(imgpath + "data");
				saveFD.InitialDirectory = Path.GetDirectoryName(imgpath);

				DialogResult result = saveFD.ShowDialog();

				if (result == DialogResult.OK)
				{
					try
					{
						// MessageBox.Show("writing diagnostics...");

						StreamWriter csv = new StreamWriter(saveFD.FileName);
						csv.WriteLine(header);

						for (int i = 0; i < imgdata.totalpixels; i ++)
						{ 
							pixel curPixel = pixels[i];
							string RGBvals = pixels[i].r + " " + pixels[i].g + " " + pixels[i].b + ",";

							if (!prop.includeWhite)
							{
								if (curPixel.value != constants.INT_WHITE) {
									csv.Write(prop.indexes ? i + "," : "");
									csv.Write(prop.integerValues ? pixels[i].value + "," : "");
									csv.Write(prop.RGBValues ? RGBvals : "");
									csv.Write("\n");
								}
							}
							else {
								csv.Write(prop.indexes ? i + "," : "");
								csv.Write(prop.integerValues ? pixels[i].value + "," : "");
								csv.Write(prop.RGBValues ? RGBvals : "");
								csv.Write("\n");
							}
						}
						// MessageBox.Show("done, wrote " + imgdata.totalpixels + " lines to: " + imgpath);

						csv.Close();
					}
					catch (Exception)
					{ }
				}
			}
		}

		public static short coltoi(Color p)
		{
			short numcolor = 0;

			if (p == constants.WHITE)
				numcolor = constants.INT_WHITE;

			/*
			//want to offset everything by 1, so color integer values run [1 -> 1021]
			else if (p.R == 255)
				numcolor = (short) (p.R + (255 - p.G) + p.B + constants.GREEN_SHIFT + 1);
			else if (p.G == 255)
				numcolor = (short) (p.R + p.G + (255 - p.B) + 1);
			else
				numcolor = (short) (p.R + p.G + p.B + 1);
			*/

			else if (p.R == 255)
				numcolor = (short) (p.R + (255 - p.G) + 510 + 1);
			else if (p.G == 255)
				numcolor = (short) (p.R + p.G + 255 + 1);
			else
				numcolor = (short)(p.G + (255 - p.B) + 1);

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
		public string imgpath;
        private pixel[] pixels = null;
        private readonly string image_err = "::IMAGE::error : ";
    }
}