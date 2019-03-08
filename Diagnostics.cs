using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BitClean
{
	public partial class Diagnostics : Form
	{
		List<ChartObject> objectList = new List<ChartObject>();

		public Diagnostics()
		{
			InitializeComponent();
		}

		private void LoadXML_Click(object sender, EventArgs e)
		{
			objectList = null;

			using (OpenFileDialog openFD = new OpenFileDialog())
			{
				string xmlpath;
				// File dialog settings
				openFD.Title = "Select an XML file";
				openFD.InitialDirectory = "C:\\Users\\100057822\\Desktop";
				openFD.Filter = "xml files (*.xml)|*.xml";
				openFD.RestoreDirectory = true;

				DialogResult result = openFD.ShowDialog();

				if (result == DialogResult.OK)
				{
					xmlpath = openFD.FileName;

					objectList = (
						from obj in XDocument.Load(xmlpath).Root.Elements("object")
						select new ChartObject
						{
							avghue = (double)obj.Element("avg_hue"),
							density = (double)obj.Element("density"),
							size = (int)obj.Element("size"),
							edgeratio = (double)obj.Element("edgeratio"),
							tag = (int)obj.Element("tag"),
							neighbors = (
								from tagnum in obj.Elements("neighbors")
								select (int)tagnum.Element("tag")
							).ToList()
						}
					).ToList();

				}
			}

		}

	}
}
