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
		private imageops img = null;
		private toolbox t = null;
		public Bitmap bmp = null;
		public string bmppath = "";

		public MainWindow()
		{
			InitializeComponent();
		}

		#region File Drop Down Buttons
		//
		// File > Load
		//
		private void loadImageFile_Click(object sender, EventArgs e)
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
					img = new imageops(bmp);

					pictureBox1.Image = img.parseImage(bmp);

					t = new toolbox(img.getpixels(), img.getimagedata());
				}
				catch (Exception)
				{
					bmp = null;
				}
			}
		}
		//
		// File > Save
		//
		private void saveImageFile_Click(object sender, EventArgs e)
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
		// Image > Set Up
		//
		private void setUpImage_Click(object sender, EventArgs e)
		{
			if (bmp == null) return;

			img = new imageops(bmp);

			pictureBox1.Image = img.parseImage(bmp);

			t = new toolbox(img.getpixels(), img.getimagedata());
		}
		//
		// Image > Bit Clean
		//
		private void bitCleanImage_Click(object sender, EventArgs e)
		{
			t.run();
			img.pushpixelstoimage(bmp);
			pictureBox1.Image = bmp;
		}
		#endregion

		#region Diagnostics Drop Down Buttons
		//
		// Diagnostics > Export All
		//
		private void exportDiagnostics_Click(object sender, EventArgs e)
		{
			Diagnostics diagnosticsWindow = new Diagnostics();
			diagnosticsWindow.Show();

			// img.exportdiagnostics(bmp, bmppath, DIAGNOSTICS.ALL);
		}
		/*
		//
		// Diagnostics > Export Non-White
		//
		private void exportNonWhiteDiagnostics_Click(object sender, EventArgs e)
		{
			img.exportdiagnostics(bmp, bmppath, DIAGNOSTICS.NON_WHITE);
		}
		*/
		#endregion

	}
}
