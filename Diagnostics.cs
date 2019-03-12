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
		string xmlStartDirectory = "";

		List<ChartObject> objectList = new List<ChartObject>();
		List<RadioButton> radioHoriztonal;
		List<RadioButton> radioVertical;

		public Diagnostics(string xmlDirectory)
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

			xmlStartDirectory = xmlDirectory;
		}

		private void LoadXML_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFD = new OpenFileDialog())
			{
				string xmlpath;
				// File dialog settings
				openFD.Title = "Select an XML file";
				openFD.InitialDirectory = xmlStartDirectory;
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

				dataGridView1.Rows.Add(obj.tag, obj.decision, obj.size, obj.avghue, obj.density, obj.edgeratio, tags, obj.neighbors.Count);	
			}
		}

		private void GenerateChart_Click(object sender, EventArgs e)
		{
			int xColIndex = 0, yColIndex = 0, decisionColIndex = 0, tagColIndex = 0;

			string horizontalChoice = radioHoriztonal.FirstOrDefault(r => r.Checked).Text;
			string verticalChoice	= radioVertical.FirstOrDefault(r => r.Checked).Text;

			foreach (DataGridViewColumn col in dataGridView1.Columns)
			{
				if (col.HeaderText == horizontalChoice)
					xColIndex = col.Index;
				if (col.HeaderText == verticalChoice)
					yColIndex = col.Index;
				if (col.HeaderText == obj_decision.HeaderText)
					decisionColIndex = col.Index;
				if (col.HeaderText == obj_tag.HeaderText)
					tagColIndex = col.Index;
			}
			

			List<object[]> datapoints = new List<object[]>();

			for (int i = 0; i < dataGridView1.Rows.Count - 1; i ++)
			{
				object[] point = 
				{
					dataGridView1.Rows[i].Cells[xColIndex].Value,
					dataGridView1.Rows[i].Cells[yColIndex].Value,
					dataGridView1.Rows[i].Cells[decisionColIndex].Value,
					dataGridView1.Rows[i].Cells[tagColIndex].Value
				};

				datapoints.Add(point);
			}
				
			
			ChartDisplay chart = new ChartDisplay(datapoints, horizontalChoice, verticalChoice);
			chart.Show();
		}

		
	}
}
