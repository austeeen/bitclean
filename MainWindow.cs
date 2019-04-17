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
		public string bmppath = "";

		private ImageOps img = null;
		private Toolbox t = null;
		private Manager xmlmanager = null;

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

			xmlmanager = new Manager();

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
				openFD.InitialDirectory = xmlmanager.ImageDirectory;
				openFD.Filter = "bmp files (*.bmp)|*.bmp";
				openFD.RestoreDirectory = true;

				DialogResult result = openFD.ShowDialog();

				if (result == DialogResult.OK) {
					bmppath = openFD.FileName;
					xmlmanager.SetImageDirectory(Path.GetDirectoryName(bmppath));
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
				saveFD.InitialDirectory = xmlmanager.XMLDirectory;

				DialogResult result = saveFD.ShowDialog();

				if (result == DialogResult.OK)
				{
					xmlmanager.SetXMLDirectory(Path.GetDirectoryName(saveFD.FileName));

					var xml = new XDocument();
					var root = new XElement("objects");
					xml.Add(root);

					for (int i = 0; i < objectdata.Count; i++)
					{
						ObjectData obj = objectdata[i];

						var objectElement = new XElement("object");
						objectElement.SetAttributeValue("tag", obj.tag);
						objectElement.SetAttributeValue("decision", obj.objconf.decision);

						var sizeElement		= new XElement("size", obj.size);
						var avgHueElement	= new XElement("avg_hue", obj.avghue);
						var densityElement	= new XElement("density", obj.density);
						var edgeRatioElement = new XElement("edge_ratio", obj.edgeratio);

						var boundsElement	= new XElement("bounds");
						var topElement		= new XElement("top", obj.bounds.top);
						var leftElement		= new XElement("left", obj.bounds.left);
						var bottomElement	= new XElement("bottom", obj.bounds.bottom);
						var rightElement	= new XElement("right", obj.bounds.right);
						boundsElement.Add(topElement);
						boundsElement.Add(leftElement);
						boundsElement.Add(bottomElement);
						boundsElement.Add(rightElement);

						var coordinatesElement = new XElement("coordinates");
						var xElement = new XElement("x", obj.position.x);
						var yElement = new XElement("y", obj.position.y);
						coordinatesElement.Add(xElement);
						coordinatesElement.Add(yElement);

						var neighborsElement = new XElement("neighbors");
						neighborsElement.SetAttributeValue("total", obj.neighbors.Count);

						for (int j = 0; j < obj.neighbors.Count; j++) {
							var neighborTagElement = new XElement("tag", obj.neighbors[j]);
							neighborsElement.Add(neighborTagElement);
						}

						objectElement.Add(sizeElement);
						objectElement.Add(avgHueElement);
						objectElement.Add(densityElement);
						objectElement.Add(edgeRatioElement);
						objectElement.Add(boundsElement);
						objectElement.Add(coordinatesElement);
						objectElement.Add(neighborsElement);

						root.Add(objectElement);
					}

					xml.Save(saveFD.FileName);

					toolStripText.Text = ToolStripMessages.XML_DATA_EXPORTED;
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
			Diagnostics diagnosticsWindow = new Diagnostics(xmlmanager);
			diagnosticsWindow.Show();
		}

		#endregion

		ImageOps getImageOpsObject() { return img; }

	}
}
