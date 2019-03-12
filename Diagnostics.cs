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
		List<RadioButton> radioHoriztonal;
		List<RadioButton> radioVertical;

		public Diagnostics()
		{
			InitializeComponent();
			radioHoriztonal = new List<RadioButton>() {
				totneighborHorizontal,
				edgeratioHorizontal,
				densityHorizontal,
				avghueHorizontal,
				sizeHorizontal,
				tagHorizontal
			};

			radioVertical = new List<RadioButton>() {
				totneighborVertical,
				edgeratioVertical,
				densityVertical,
				avghueVertical,
				sizeVertical,
				tagVertical
			};
		}

		private void LoadXML_Click(object sender, EventArgs e)
		{
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
					GetXMLData(xmlpath);
				}

				if(objectList.Count > 0)
				{
					SetUpChartData();
				}
			}

		}

		private void GetXMLData(string path)
		{
			XElement doc = XDocument.Load(path).Root;

			foreach (var obj in doc.Descendants("object"))
			{
				ChartObject chartObject = new ChartObject();

				chartObject.tag = (int)obj.Attribute("tag");
				chartObject.decision = (string)obj.Attribute("decision");

				chartObject.size = (int)obj.Element("size");
				chartObject.avghue = (double)obj.Element("avg_hue");
				chartObject.density = (double)obj.Element("density");
				chartObject.edgeratio = (double)obj.Element("edge_ratio");

				chartObject.neighbors = new List<int>();
				foreach (var neighbor in obj.Descendants("tag"))
					chartObject.neighbors.Add((int)neighbor);

				objectList.Add(chartObject);
			}
		}

		private void SetUpChartData()
		{
			foreach (ChartObject obj in objectList)
			{
				string tags = "";
				foreach (int tag in obj.neighbors)
					tags += tag + ",";
				// size, avg hue, density, edge ratio, neighbors
				string[] row = {
					obj.tag.ToString(),
					obj.size.ToString(),
					obj.avghue.ToString(),
					obj.density.ToString(),
					obj.edgeratio.ToString(),
					tags,
					obj.neighbors.Count.ToString()
				};
				dataGridView1.Rows.Add(row);	
			}
		}

		private void GenerateChart_Click(object sender, EventArgs e)
		{
			int xColIndex = 0, yColIndex = 0;

			string horizontalChoice = radioHoriztonal.FirstOrDefault(r => r.Checked).Text;
			string verticalChoice	= radioVertical.FirstOrDefault(r => r.Checked).Text;

			foreach (DataGridViewColumn col in dataGridView1.Columns) {
				if (col.HeaderText == horizontalChoice)
					xColIndex = col.Index;
			}

			foreach (DataGridViewColumn col in dataGridView1.Columns) {
				if (col.HeaderText == verticalChoice)
					yColIndex = col.Index;
			}

			List<string[]> datapoints = new List<string[]>();

			for (int i = 0; i < dataGridView1.Rows.Count - 1; i ++) {
				string[] point = {
					dataGridView1.Rows[i].Cells[xColIndex].Value.ToString(),
					dataGridView1.Rows[i].Cells[yColIndex].Value.ToString()
				};
				datapoints.Add(point);
			}
				
			
			ChartDisplay chart = new ChartDisplay(datapoints);
			chart.Show();
		}

		
	}
}
