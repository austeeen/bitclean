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

		public MainWindow()
		{
			InitializeComponent();
			StartUp();
		}

		public void StartUp()
		{
			saveImageMenuStripItem.Enabled	= false;
			bitCleanMenuStripItem.Enabled	= false;
			exportMenuStripItem.Enabled		= false;
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
					bitCleanMenuStripItem.Enabled	= true;
					saveImageMenuStripItem.Enabled	= true;
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
			if (bmp != null)
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
			else
				MessageBox.Show("no image loaded!");
		}
		#endregion

		#region Image Drop Down Buttons
		//
		// Image > Bit Clean
		//
		private void BitCleanImage_Click(object sender, EventArgs e)
		{
			if (img != null && t != null)
			{
				t.Run();
				img.PushPixelsToImage(bmp);
				pictureBox1.Image = bmp;
				diagnosticsMenuStripItem.Visible = true;
				MessageBox.Show("done");
				exportMenuStripItem.Enabled = true;
			}
			else
				MessageBox.Show("no image loaded!");
		}
		#endregion

		#region Diagnostics Drop Down Buttons
		//
		// Diagnostics > Export to XML...
		//
		private void ExportDiagnostics_Click(object sender, EventArgs e)
		{
			string imgpath = img.GetImagePath();
			List<ObjectData> objectdata = t.GetObjectData();

			// write all data into xml file format
			using (var saveFD = new SaveFileDialog())
			{
				saveFD.Title = "Save the diagostics xml file";
				saveFD.Filter = "xml files (*.xml)|*.xml";

				saveFD.FileName = Path.GetFileNameWithoutExtension(imgpath + "data");
				saveFD.InitialDirectory = Path.GetDirectoryName(imgpath);

				DialogResult result = saveFD.ShowDialog();

				if (result == DialogResult.OK)
				{
					using (StreamWriter xml = new StreamWriter(saveFD.FileName))
					{
						// prologue
						xml.WriteLine(XML.prologue);
						xml.WriteLine(XML.root);

						for (int i = 0; i < objectdata.Count; i++)
						{
							ObjectData obj = objectdata[i];
							
							// write header with tag/decision attributes
							xml.WriteLine(XML.object_header + "tag=\"" + obj.tag + "\" decision=\"" + obj.objconf.decision + "\">");

							// size, average hue, density, edge ratio
							xml.WriteLine("\t" + XML.size + obj.size + XML.size_end);
							xml.WriteLine("\t" + XML.avgHue + obj.avghue + XML.avgHue_end);
							xml.WriteLine("\t" + XML.density + obj.density + XML.density_end);
							xml.WriteLine("\t" + XML.edgeRatio + obj.edgeratio + XML.edgeRatio_end);

							// object bounds
							xml.WriteLine("\t" + XML.bounds);
							xml.WriteLine("\t\t" + XML.top + obj.bounds.top + XML.top_end);
							xml.WriteLine("\t\t" + XML.left + obj.bounds.left + XML.left_end);
							xml.WriteLine("\t\t" + XML.bottom + obj.bounds.bottom + XML.bottom_end);
							xml.WriteLine("\t\t" + XML.right + obj.bounds.right + XML.right_end);
							xml.WriteLine("\t" + XML.bounds_end);

							// object coordinates
							xml.WriteLine("\t" + XML.coordinates);
							xml.WriteLine("\t\t" + XML.x + obj.position.x + XML.x_end);
							xml.WriteLine("\t\t" + XML.y + obj.position.y + XML.y_end);
							xml.WriteLine("\t" + XML.coordinates_end);

							// write each neighbor
							xml.WriteLine("\t" + XML.neighbors);
							for (int j = 0; j < obj.neighbors.Count; j++)
								xml.WriteLine("\t\t" + XML.tag + obj.neighbors[j] + XML.tag_end);
							xml.WriteLine("\t" + XML.neighbors_end);

							xml.WriteLine(XML.object_header_end);
						}

						xml.WriteLine(XML.root_end);
					}	
				}
				else
					MessageBox.Show("export failed");
			}

		}
		//
		// Diagnostics > View Diagnostics Window
		//
		private void Plots_Click(object sender, EventArgs e)
		{
			Diagnostics diagnosticsWindow = new Diagnostics();
			diagnosticsWindow.Show();
		}

		#endregion

		ImageOps getImageOpsObject() { return img; }
	}
}
