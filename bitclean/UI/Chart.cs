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
        List<object[]> objects;
        TreeViewColumn[] treeColumns;
        int xChoiceIndx, yChoiceIndx, decisionIndx;
        List<double[]> data;

        public Chart(List<object[]> objects, ChartOptions configuration, TreeViewColumn[] columns) : base(WindowType.Toplevel)
        {
            Build();

            this.objects = objects;
            this.configuration = configuration;
            treeColumns = columns;

            //Set up data

            // create a new plot surface, call set up function
            NPlot.Gtk.PlotSurface2D testplot = new NPlot.Gtk.PlotSurface2D();
            Plot(testplot);

            // add plot surface to the window and show it
            testplot.Show();
            Add(testplot);
            ShowAll();
        }

        private void SetUpData()
        {
            // relate radio button choice to tree view column
            // and get decision column index for filtering data
            for (int i = 0; i < treeColumns.Length; i ++) {
                if (treeColumns[i].Title == configuration.horizontalChoice)
                    xChoiceIndx = i;
                if (treeColumns[i].Title == configuration.verticalChoice)
                    yChoiceIndx = i;
                if (treeColumns[i].Title == "Decision")
                    decisionIndx = i;
            }

            // populate xaxis/yaxis with filtered data
            for (int i = 0; i < objects.Count; i ++)
            {
                if(configuration.dust) // check dust filter
                {
                    if (objects[i][decisionIndx].ToString() == "dust")
                    {
                        data.Add(new double[]
                        {
                            Convert.ToDouble(objects[i][xChoiceIndx]), // x data point
                            Convert.ToDouble(objects[i][yChoiceIndx])  // y data point
                        });
                    }
                }
                if(configuration.structures) // check structure filter
                {
                    if (objects[i][decisionIndx].ToString() == "structure")
                    {
                        data.Add(new double[]
                        {
                            Convert.ToDouble(objects[i][xChoiceIndx]), // x data point
                            Convert.ToDouble(objects[i][yChoiceIndx])  // y data point
                        });
                    }
                }

            }

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
