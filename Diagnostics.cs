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

namespace BitClean
{
	public partial class Diagnostics : Form
	{
		private string imgpath = null;
		private pixel[] pixels;
		private List<objectData> objectdata;

		public Diagnostics(string imgpath, bool imageloaded, bool imagecleaned, pixel[] pixels, List<objectData> objectdata)
		{
			InitializeComponent();
			this.imgpath = imgpath;
			PixelPropertiesCheckList.Visible = imageloaded;
			ConfidencePropertiesCheckList.Visible = imagecleaned;
			this.pixels = pixels;
			this.objectdata = objectdata;
		}

		private void exportPixelsButton_Click(object sender, EventArgs e)
		{
			string header = "";
			pixelDiagnosticsProperties properties;
			properties.includeWhite	 = false;
			properties.integerValues = false;
			properties.RGBValues	 = false;
			properties.indexes		 = false;

			if (PixelPropertiesCheckList.GetItemCheckState(0) == CheckState.Checked) {
				// White Pixels
				properties.includeWhite = true;
			}
			if (PixelPropertiesCheckList.GetItemCheckState(3) == CheckState.Checked) {
				// Indexes
				header += "indx,";
				properties.indexes = true;
			}
			if (PixelPropertiesCheckList.GetItemCheckState(1) == CheckState.Checked) {
				// Integer Values
				header += "int val,";
				properties.integerValues = true;
			}
			if (PixelPropertiesCheckList.GetItemCheckState(2) == CheckState.Checked) {
				// RGB Values
				header += "RGB val";
				properties.RGBValues = true;
			}

			// run same for object properties
			if(header != "")
				exportPixeldiagnostics(header, properties);
		}

		private void exportConfidenceButton_Click(object sender, EventArgs e)
		{
			string header = "";
			confidenceDiagnosticsProperties properties;
			properties.objectdecision	= false;
			properties.totalsize		= false;
			properties.averagehue		= false;
			properties.valuedensity		= false;
			properties.edgeratio		= false;

			if (ConfidencePropertiesCheckList.GetItemCheckState(0) == CheckState.Checked) { // structure or dust
				header += "obj(s|d),";
				properties.objectdecision = true;
			}
			if (ConfidencePropertiesCheckList.GetItemCheckState(3) == CheckState.Checked) { // total size
				header += "size,";
				properties.totalsize = true;
			}
			if (ConfidencePropertiesCheckList.GetItemCheckState(1) == CheckState.Checked) { // average hue
				header += "avg_hue,";
				properties.averagehue = true;
			}
			if (ConfidencePropertiesCheckList.GetItemCheckState(2) == CheckState.Checked) { // value density
				header += "density,";
				properties.valuedensity = true;
			}
			if (ConfidencePropertiesCheckList.GetItemCheckState(2) == CheckState.Checked) { // edge ratio
				header += "edge,";
				properties.edgeratio = true;
			}

			// run same for object properties
			if (header != "")
				exportConfidencediagnostics(header, properties);
		}

		public void exportPixeldiagnostics(string header, pixelDiagnosticsProperties prop)
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
						StreamWriter csv = new StreamWriter(saveFD.FileName);
						csv.WriteLine(header);

						for (int i = 0; i < pixels.Length; i++)
						{
							pixel curPixel = pixels[i];
							string RGBvals = pixels[i].r + " " + pixels[i].g + " " + pixels[i].b + ",";

							if (!prop.includeWhite)
							{
								if (curPixel.value != constants.INT_WHITE)
								{
									csv.Write(prop.indexes ? i + "," : "");
									csv.Write(prop.integerValues ? pixels[i].value + "," : "");
									csv.Write(prop.RGBValues ? RGBvals : "");
									csv.Write("\n");
								}
							}
							else
							{
								csv.Write(prop.indexes ? i + "," : "");
								csv.Write(prop.integerValues ? pixels[i].value + "," : "");
								csv.Write(prop.RGBValues ? RGBvals : "");
								csv.Write("\n");
							}
						}
						csv.Close();
					}
					catch (Exception)
					{ }
				}
			}
		}

		public void exportConfidencediagnostics(string header, confidenceDiagnosticsProperties prop)
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
						StreamWriter csv = new StreamWriter(saveFD.FileName);
						csv.WriteLine(header);

						//iterate through object data

						csv.Close();
					}
					catch (Exception)
					{ }
				}
			}
		}
	}
}
