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
		public ChartDisplay(List<string[]> data)
		{
			InitializeComponent();

			foreach (string[] point in data)
				chart1.Series["Series1"].Points.AddXY(point[0], point[1]);

			chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;

		}
	}
}
