using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitClean
{
	public partial class Diagnostics : Form
	{
		public imageops imgobj = null;

		public Diagnostics(imageops imageopsobject)
		{
			InitializeComponent();
			imgobj = imageopsobject;
		}

		private void exportButton_Click(object sender, EventArgs e)
		{
			//export diagnostics given check box choices

			//build csv header

			//open file dialog to save
			//use check list to write each line
			string header = "";
			diagnosticsProperties properties;
			properties.includeWhite		= false;
			properties.integerValues	= false;
			properties.RGBValues		= false;
			properties.indexes			= false;

			if(imgobj == null)
				MessageBox.Show("imageobject null");

			if (PixelPropertiesCheckList.GetItemCheckState(0) == CheckState.Checked) {
				//White Pixels
				properties.includeWhite = true;
			}
			if (PixelPropertiesCheckList.GetItemCheckState(3) == CheckState.Checked) {
				//Indexes
				header += "indx,";
				properties.indexes = true;
			}
			if (PixelPropertiesCheckList.GetItemCheckState(1) == CheckState.Checked) {
				//Integer Values
				header += "int val,";
				properties.integerValues = true;
			}
			if (PixelPropertiesCheckList.GetItemCheckState(2) == CheckState.Checked) {
				//RGB Values
				header += "RGB val,";
				properties.RGBValues = true;
			}

			imgobj.exportdiagnostics(header, properties);
			MessageBox.Show("diagnostics done");

		}

	}
}
