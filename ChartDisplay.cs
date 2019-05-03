using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

/*
 * bitclean: ChartDisplay.cs
 * Author: Austin Herman
 * 3/14/2019
 */

namespace BitClean
{
	public partial class ChartDisplay : Form
	{
		private List<object[]> points;
		private ActivationFunction func;
		private string xAxisLabel, yAxisLabel, functionChoice;
		private bool dust, structure;

		private System.Windows.Forms.DataVisualization.Charting.Series
			dustSeries, strucSeries, occurenceSeries;


		public ChartDisplay(List<object[]> data, string xAxisLabel, string yAxisLabel, bool dust, bool structure, string functionChoice)
		{
			InitializeComponent();

			points = data;
			this.xAxisLabel = xAxisLabel;
			this.yAxisLabel = yAxisLabel;
			this.functionChoice = functionChoice;
			this.dust = dust;
			this.structure = structure;

			chart1.Series.Remove(chart1.Series[0]);

			if (functionChoice == "occurence")
				ChartOccurence();
			else
				ChartScatter();


			chart1.ChartAreas[0].AxisX.Title = xAxisLabel;
			chart1.ChartAreas[0].AxisY.Title = yAxisLabel;

		}

		#region scatter plot
		public void ChartScatter()
		{
			if (dust)
				dustSeries = new System.Windows.Forms.DataVisualization.Charting.Series("dust");
			if (structure)
				strucSeries = new System.Windows.Forms.DataVisualization.Charting.Series("structure");

			GetFunction(functionChoice);

			foreach (object[] point in points)
			{
				System.Windows.Forms.DataVisualization.Charting.DataPoint pt = new System.Windows.Forms.DataVisualization.Charting.DataPoint();

				double yval = func.Activate(Convert.ToDouble(point[1]));

				pt.SetValueXY(point[0], yval);
				pt.ToolTip = string.Format("{0}: {1}, {2}", point[3], point[0], yval);

				if (point[2].ToString() == "dust" && dustSeries != null)
					dustSeries.Points.Add(pt);
				else if(strucSeries != null)
					strucSeries.Points.Add(pt);

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

		}

		private void GetFunction(string choice)
		{
			if (choice == "logistic")
				func = new Logistic(13, 0.0039, 1);
			else
				func = new Linear();
		}
		#endregion

		#region occurence
		private void ChartOccurence()
		{
			List<int> occurences = new List<int>();

			for (int i = 0; i < points.Count; i++)
			{
				while (occurences.Count != Convert.ToInt32(points[i][1]))
					occurences.Add(0);

				occurences[Convert.ToInt32(points[i][1])]++;
			}

			occurenceSeries = new System.Windows.Forms.DataVisualization.Charting.Series("occurences");

			for (int i = 0; i < occurences.Count; i++)
			{
				System.Windows.Forms.DataVisualization.Charting.DataPoint pt = new System.Windows.Forms.DataVisualization.Charting.DataPoint();

				pt.SetValueXY(i, occurences[i]);
				pt.ToolTip = string.Format("{0}, {1}", i, occurences[i]);

				occurenceSeries.Points.Add(pt);

			}

			occurenceSeries.Color = Color.Tomato;
			occurenceSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
			chart1.Series.Add(occurenceSeries);

			xAxisLabel = yAxisLabel;
			yAxisLabel = "occurences";

		}
		#endregion
	}
}
