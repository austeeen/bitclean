using System;
using Gtk;
using NPlot;
using NPlot.Gtk;
using System.Drawing;
using System.Collections.Generic;

namespace bitclean.UI
{
    /// <summary>
    /// A window for displaying plotted data
    /// </summary>
    public partial class Chart : Window
    {
        ChartOptions configuration;
        List<ChartObject> objects;
        double[] xData, yData;

        public Chart(List<ChartObject> objects, ChartOptions configuration) : base(WindowType.Toplevel)
        {
            Build();

            this.objects = objects;
            this.configuration = configuration;

            //Set up data

            // create a new plot surface, call set up function
            NPlot.Gtk.PlotSurface2D testplot = new NPlot.Gtk.PlotSurface2D();
            Plot(testplot);

            // add plot surface to the window and show it
            testplot.Show();
            this.Add(testplot);
            this.ShowAll();
        }

        private void SetUpData()
        {
            // populate xaxis with filtered data

            // populate yaxis with filtered data

            // preprocess data

            // put data through function choice

        }

        private void Plot(IPlotSurface2D plotSurface)
        {
            plotSurface.Clear();

            // create a new point plot and give it data
            // change it's marker type
            PointPlot plot = new PointPlot {
                DataSource = GenerateData(),
                Marker = new Marker(Marker.MarkerType.Circle)
            };

            // set up a grid for viewability and add it to the plot surface
            Grid myGrid = new Grid {
                VerticalGridType = Grid.GridType.Fine,
                HorizontalGridType = Grid.GridType.Coarse
            };
            plotSurface.Add(myGrid);

            // add the plot to the plot surface, give it a title
            plotSurface.Add(plot);
            plotSurface.Title = "Test Point Plot";

        }

        private double[] GenerateData()
        {
            double[] a = new double[10];

            for (int i = 0; i < 10; i++)
                a[i] = i;

            return a;
        }
    }
}
