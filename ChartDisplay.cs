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
		private ActivationFunction func;

		public ChartDisplay(List<object[]> data, string xAxisLabel, string yAxisLabel, bool dust, bool structure, string functionChoice)
		{
			InitializeComponent();

			GetFunction(functionChoice);

			points = data;

			System.Windows.Forms.DataVisualization.Charting.Series dustSeries = null;
			System.Windows.Forms.DataVisualization.Charting.Series strucSeries = null;

			if (dust)
				dustSeries	= new System.Windows.Forms.DataVisualization.Charting.Series("dust");
			if(structure)
				strucSeries	= new System.Windows.Forms.DataVisualization.Charting.Series("structure");

			chart1.Series.Remove(chart1.Series[0]);

			foreach (object[] point in points)
			{
				System.Windows.Forms.DataVisualization.Charting.DataPoint pt = new System.Windows.Forms.DataVisualization.Charting.DataPoint();

				double yval = func.Activate(Convert.ToDouble(point[1]));

				if (point[2].ToString() == "dust" && dustSeries != null)
				{
					pt.SetValueXY(point[0], yval);
					pt.ToolTip = string.Format("{0}: {1}, {2}", point[3], point[0], yval);
					dustSeries.Points.Add(pt);
				}
				else if(strucSeries != null)
				{
					pt.SetValueXY(point[0], yval);
					pt.ToolTip = string.Format("{0}: {1}, {2}", point[3], point[0], yval);
					strucSeries.Points.Add(pt);
				}
			}

			if(dustSeries != null)
			{
				dustSeries.Color = Color.BlueViolet;
				dustSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
				chart1.Series.Add(dustSeries);
			}

			if(strucSeries != null)
			{
				strucSeries.Color = Color.ForestGreen;
				strucSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
				chart1.Series.Add(strucSeries);
			}


			chart1.ChartAreas[0].AxisX.Title = xAxisLabel;
			chart1.ChartAreas[0].AxisY.Title = yAxisLabel;

		}

		private void GetFunction(string choice)
		{
			if (choice == "logistic")
				func = new Logistic(1000.0, 0.001, 1);
			else
				func = new Linear();
		}
	}
}
