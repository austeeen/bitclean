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
	public partial class ChartDisplay : Form
	{
		private List<object[]> points;

		public ChartDisplay(List<object[]> data, string xAxisLabel, string yAxisLabel)
		{
			InitializeComponent();

			points = data;

			System.Windows.Forms.DataVisualization.Charting.Series dustSeries	= new System.Windows.Forms.DataVisualization.Charting.Series("dust");
			System.Windows.Forms.DataVisualization.Charting.Series strucSeries	= new System.Windows.Forms.DataVisualization.Charting.Series("structure");
			chart1.Series.Remove(chart1.Series[0]);

			foreach (object[] point in points)
			{
				System.Windows.Forms.DataVisualization.Charting.DataPoint pt = new System.Windows.Forms.DataVisualization.Charting.DataPoint();

				if (point[2].ToString() == "dust") {
					pt.SetValueXY(point[0], point[1]);
					pt.ToolTip = string.Format("{0}: {1}, {2}", point[3], point[0], point[1]);
					dustSeries.Points.Add(pt);	
				}
				else {
					pt.SetValueXY(point[0], point[1]);
					pt.ToolTip = string.Format("{0}: {1}, {2}", point[3], point[0], point[1]);
					strucSeries.Points.Add(pt);
				}
			}

			dustSeries.Color = Color.BlueViolet;
			dustSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

			strucSeries.Color = Color.ForestGreen;
			strucSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

			chart1.Series.Add(dustSeries);
			chart1.Series.Add(strucSeries);

			chart1.ChartAreas[0].AxisX.Title = xAxisLabel;
			chart1.ChartAreas[0].AxisY.Title = yAxisLabel;

		}
	}
}
