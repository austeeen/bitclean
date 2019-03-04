using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/*
 * Bitclean: MainWindow.cs
 * Author: Austin Herman
 * 2/13/2019
 */

namespace BitClean
{
	public partial class MainWindow : Form
	{
		public Bitmap bmp = null;
		public string bmppath = "";

		private ImageOps img = null;
		private Toolbox t = null;
		private bool imageloaded = false, imagecleaned = false;

		public MainWindow()
		{
			InitializeComponent();
		}

		#region File Drop Down Buttons
		//
		// File > Load
		//
		private void LoadImageFile_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFD = new OpenFileDialog())
			{
				// File dialog settings
				openFD.Title = "Select an image file";
				openFD.InitialDirectory = "C:\\Users\\100057822\\Desktop";
				openFD.Filter = "bmp files (*.bmp)|*.bmp";
				openFD.RestoreDirectory = true;

				DialogResult result = openFD.ShowDialog();

				if (result == DialogResult.OK)
					bmppath = openFD.FileName;

				try
				{
					bmp = new Bitmap(Image.FromFile(bmppath));
					img = new ImageOps(bmp, bmppath);

					pictureBox1.Image = img.ParseImage(bmp);

					t = new Toolbox(img.GetPixels(), img.GetImageData());
					imageloaded = true;
				}
				catch (Exception) {
					bmp = null;
				}
			}
		}
		//
		// File > Save
		//
		private void SaveImageFile_Click(object sender, EventArgs e)
		{
			// Get the file's save name
			SaveFileDialog saveFD = new SaveFileDialog();

			saveFD.Title = "Save the image file";
			saveFD.Filter = "bmp files (*.bmp)|*.bmp";

			saveFD.FileName = Path.GetFileNameWithoutExtension(bmppath);

			saveFD.InitialDirectory = Path.GetDirectoryName(bmppath);

			DialogResult result = saveFD.ShowDialog();

			if (result == DialogResult.OK)
				bmp.Save(saveFD.FileName);
			else
				MessageBox.Show("File was not saved.", "File Not Saved", 0);
		}
		#endregion

		#region Image Drop Down Buttons
		//
		// Image > Bit Clean
		//
		private void BitCleanImage_Click(object sender, EventArgs e)
		{
			t.Run();
			img.PushPixelsToImage(bmp);
			pictureBox1.Image = bmp;
			imagecleaned = true;
		}
		#endregion

		#region Diagnostics Drop Down Buttons
		//
		// Diagnostics > Export All
		//
		private void ExportDiagnostics_Click(object sender, EventArgs e)
		{
			Diagnostics diagnosticsWindow = new Diagnostics(img.GetImagePath(), imageloaded, imagecleaned, img.GetPixels(), t.GetObjectData());
			diagnosticsWindow.Show();
		}

		#endregion

		ImageOps getImageOpsObject() { return img; }
	}
}
