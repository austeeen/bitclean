using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Xml.Linq;
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
		public string executablePath = "",
					imgDirectory = "",
					xmlDirectory = "",
					bmppath = "";

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
			toolStripText.Text = ToolStripMessages.DEFAULT_MESSAGE;

			executablePath = Path.GetDirectoryName(Application.ExecutablePath);

			//populate from metadata file
			XElement doc = XDocument.Load(executablePath + Constants.META_DATA_PATH + Constants.META_PATHS).Root;
			imgDirectory = (string) doc.Attribute("bmp_image");
			xmlDirectory = (string) doc.Attribute("xml_data");
			
			if (imgDirectory == "") imgDirectory = Constants.MY_START_PATH;
			if (xmlDirectory == "") xmlDirectory = Constants.MY_START_PATH;

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
				openFD.InitialDirectory = imgDirectory;
				openFD.Filter = "bmp files (*.bmp)|*.bmp";
				openFD.RestoreDirectory = true;

				DialogResult result = openFD.ShowDialog();

				if (result == DialogResult.OK) {
					bmppath = openFD.FileName;
					imgDirectory = Path.GetDirectoryName(bmppath);
					storeXMLDiagnosticsMetadata();
				}

				try
				{
					toolStripText.Text = ToolStripMessages.IMAGE_LOADING;
					statusStrip1.Refresh();

					bmp = new Bitmap(Image.FromFile(bmppath));
					img = new ImageOps(bmp, bmppath);

					pictureBox1.Image = img.ParseImage(bmp);

					t = new Toolbox(img.GetPixels(), img.GetImageData());
					bitCleanMenuStripItem.Enabled	= true;
					saveImageMenuStripItem.Enabled	= true;
					toolStripText.Text = ToolStripMessages.IMAGE_LOADED;
				}
				catch (Exception) {
					toolStripText.Text = ToolStripMessages.IMAGE_LOAD_FAILED;
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

				if (result == DialogResult.OK) {
					bmp.Save(saveFD.FileName);
					toolStripText.Text = ToolStripMessages.IMAGE_SAVED;
				}
				else {
					toolStripText.Text = ToolStripMessages.IMAGE_SAVE_FAILED;
					MessageBox.Show("File was not saved.", "File Not Saved", 0);
				}
					
			}
			else {
				toolStripText.Text = ToolStripMessages.IMAGE_SAVE_FAILED;
				MessageBox.Show("no image loaded!");
			}
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
				toolStripText.Text = ToolStripMessages.CLEANING_IMAGE;
				statusStrip1.Refresh();

				t.Run(progressBar, statusStrip1, toolStripText);

				img.PushPixelsToImage(bmp);

				pictureBox1.Image = bmp;

				diagnosticsMenuStripItem.Visible = true;
				exportMenuStripItem.Enabled = true;

				MessageBox.Show("done");
				toolStripText.Text = ToolStripMessages.IMAGE_CLEANED;
			}
			else
				MessageBox.Show("no image loaded!");
		}
		#endregion

		#region Diagnostics Drop Down Buttons
		//
		// Diagnostics > Export to XMLDiagnostics...
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
				saveFD.InitialDirectory = xmlDirectory;

				DialogResult result = saveFD.ShowDialog();

				if (result == DialogResult.OK)
				{
					xmlDirectory = Path.GetDirectoryName(saveFD.FileName);
					storeXMLDiagnosticsMetadata();

					using (StreamWriter xml = new StreamWriter(saveFD.FileName))
					{
						// prologue
						xml.WriteLine(XMLDiagnostics.prologue);
						xml.WriteLine(XMLDiagnostics.root);

						for (int i = 0; i < objectdata.Count; i++)
						{
							ObjectData obj = objectdata[i];
							
							// write header with tag/decision attributes
							xml.WriteLine(XMLDiagnostics.object_header + "tag=\"" + obj.tag + "\" decision=\"" + obj.objconf.decision + "\">");

							// size, average hue, density, edge ratio
							xml.WriteLine("\t" + XMLDiagnostics.size + obj.size + XMLDiagnostics.size_end);
							xml.WriteLine("\t" + XMLDiagnostics.avgHue + obj.avghue + XMLDiagnostics.avgHue_end);
							xml.WriteLine("\t" + XMLDiagnostics.density + obj.density + XMLDiagnostics.density_end);
							xml.WriteLine("\t" + XMLDiagnostics.edgeRatio + obj.edgeratio + XMLDiagnostics.edgeRatio_end);

							// object bounds
							xml.WriteLine("\t" + XMLDiagnostics.bounds);
							xml.WriteLine("\t\t" + XMLDiagnostics.top + obj.bounds.top + XMLDiagnostics.top_end);
							xml.WriteLine("\t\t" + XMLDiagnostics.left + obj.bounds.left + XMLDiagnostics.left_end);
							xml.WriteLine("\t\t" + XMLDiagnostics.bottom + obj.bounds.bottom + XMLDiagnostics.bottom_end);
							xml.WriteLine("\t\t" + XMLDiagnostics.right + obj.bounds.right + XMLDiagnostics.right_end);
							xml.WriteLine("\t" + XMLDiagnostics.bounds_end);

							// object coordinates
							xml.WriteLine("\t" + XMLDiagnostics.coordinates);
							xml.WriteLine("\t\t" + XMLDiagnostics.x + obj.position.x + XMLDiagnostics.x_end);
							xml.WriteLine("\t\t" + XMLDiagnostics.y + obj.position.y + XMLDiagnostics.y_end);
							xml.WriteLine("\t" + XMLDiagnostics.coordinates_end);

							// write each neighbor
							xml.WriteLine("\t" + XMLDiagnostics.neighbors);
							for (int j = 0; j < obj.neighbors.Count; j++)
								xml.WriteLine("\t\t" + XMLDiagnostics.tag + obj.neighbors[j] + XMLDiagnostics.tag_end);
							xml.WriteLine("\t" + XMLDiagnostics.neighbors_end);

							xml.WriteLine(XMLDiagnostics.object_header_end);
						}

						xml.WriteLine(XMLDiagnostics.root_end);
						toolStripText.Text = ToolStripMessages.XML_DATA_EXPORTED;
					}	
				}
				else {
					toolStripText.Text = ToolStripMessages.XML_EXPORT_FAILED;
					MessageBox.Show("export failed");
				}
					
			}

		}
		//
		// Diagnostics > View Diagnostics Window
		//
		private void Plots_Click(object sender, EventArgs e)
		{
			Diagnostics diagnosticsWindow = new Diagnostics(xmlDirectory);
			diagnosticsWindow.Show();
		}

		#endregion

		ImageOps getImageOpsObject() { return img; }

		private void storeXMLDiagnosticsMetadata()
		{
			using (StreamWriter xml = new StreamWriter(executablePath + Constants.META_DATA_PATH + Constants.META_PATHS))
			{
				// prologue
				xml.WriteLine(XMLMetaData.prologue);
				// write header with file path attributes
				xml.WriteLine(XMLMetaData.root + "\n\tbmp_image=\"" + imgDirectory + "\"\n\txml_data=\"" + xmlDirectory + "\"\n/>");
			}
		}
	}
}
