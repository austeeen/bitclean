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
        int xChoiceIndx, yChoiceIndx, decisionIndx, tagIndx;
        List<List<double>> dustdata, structdata;

        public Chart(List<object[]> objects, ChartOptions configuration, TreeViewColumn[] columns) : base(WindowType.Toplevel)
        {
            Build();

            this.objects = objects;
            this.configuration = configuration;
            treeColumns = columns;

            if(objects.Count > 0)
            {
                // set up data
                dustdata = new List<List<double>>();
                structdata = new List<List<double>>();

                SetUpData();

                // create a new plot surface, call plot set up
                NPlot.Gtk.PlotSurface2D testplot = new NPlot.Gtk.PlotSurface2D();
                Plot(testplot);

                // add plot surface to the window and show it
                testplot.Show();
                Add(testplot);
                ShowAll();
            }
            else // no data, print message
            {
                Console.WriteLine("No data to plot.");
                Label noDataLabel = new Label {
                    Text = "No data to plot."
                };
                noDataLabel.Show();
                Add(noDataLabel);
                ShowAll();
            }
        }

        private void SetUpData()
        {
            // relate radio button choice to tree view column
            // and get decision column index for filtering data
            for (int i = 0; i < treeColumns.Length; i ++) 
            {
                if (treeColumns[i].Title == configuration.horizontalChoice)
                    xChoiceIndx = i;
                if (treeColumns[i].Title == configuration.verticalChoice)
                    yChoiceIndx = i;
                if (treeColumns[i].Title == "Decision")
                    decisionIndx = i;
                if (treeColumns[i].Title == "Tag")
                    tagIndx = i;
            }

            // TODO: run a configuration.squared and tag = x or y choice index check and handle appropriately

            // populate xaxis/yaxis with filtered data
            try {
                PopulateData();
            }
            catch (Exception excp) {
                Console.WriteLine(excp.Message);
                Console.WriteLine(excp.Data);
            }

            // preprocess data - TODO: make axis independent
            PreprocessData();

            // put yAxis through function choice - TODO: make function axis independent
            ProcessFunction();

        }

        private void Plot(IPlotSurface2D plotSurface)
        {
            plotSurface.Clear();

            // create dust/structure point plots and give them data
            // change it's marker type
            PointPlot dustPlot = new PointPlot {
                AbscissaData = dustdata[0], // add x axis
                OrdinateData = dustdata[1], // add y axis
                Marker = new Marker(Marker.MarkerType.Circle)
            };
            PointPlot structplot = new PointPlot {
                AbscissaData = structdata[0], // add x axis
                OrdinateData = structdata[1], // add y axis
                Marker = new Marker(Marker.MarkerType.Diamond)
            };

            // set up a grid for viewability
            Grid myGrid = new Grid {
                VerticalGridType = Grid.GridType.Fine,
                HorizontalGridType = Grid.GridType.Coarse
            };

            // add grid to plot surface
            plotSurface.Add(myGrid);

            // add the plots to the plot surface, give it a title
            plotSurface.Add(dustPlot);
            plotSurface.Add(structplot);
            plotSurface.Title = configuration.verticalChoice + " vs " + configuration.horizontalChoice;
        }

        private void PopulateData()
        {
            dustdata.Add(new List<double>()); // index 0 = xaxis
            dustdata.Add(new List<double>()); // index 1 = yaxis

            structdata.Add(new List<double>()); // index 0 = xaxis
            structdata.Add(new List<double>()); // index 1 = yaxis

            for (int i = 0; i < objects.Count; i++)
            {
                // check dust filter
                if (configuration.dust && objects[i][decisionIndx].ToString() == "dust") {
                    dustdata[0].Add(Convert.ToDouble(objects[i][xChoiceIndx]));
                    dustdata[1].Add(Convert.ToDouble(objects[i][yChoiceIndx]));
                }
                // check structure filter
                if (configuration.structures && objects[i][decisionIndx].ToString() == "structure") {
                    structdata[0].Add(Convert.ToDouble(objects[i][xChoiceIndx]));
                    structdata[1].Add(Convert.ToDouble(objects[i][yChoiceIndx]));
                }
            }
        }

        private void PreprocessData()
        {
            if (configuration.squared)
            {
                for (int i = 0; i < dustdata[0].Count; i++)
                {
                    if (xChoiceIndx != tagIndx)
                        dustdata[0][i] = Math.Pow(dustdata[0][i], 2);
                    if (yChoiceIndx != tagIndx)
                        dustdata[1][i] = Math.Pow(dustdata[1][i], 2);
                }

                for (int i = 0; i < structdata[0].Count; i++)
                {
                    if (xChoiceIndx != tagIndx)
                        structdata[0][i] = Math.Pow(structdata[0][i], 2);
                    if (yChoiceIndx != tagIndx)
                        structdata[1][i] = Math.Pow(structdata[1][i], 2);
                }
            }
        }

        private void ProcessFunction()
        {
            if (configuration.function.ToString() != "bitclean.Linear")
            {
                for (int i = 0; i < dustdata[0].Count; i++)
                    dustdata[1][i] = configuration.function.Activate(dustdata[1][i]);
                for (int i = 0; i < structdata[0].Count; i++)
                    structdata[1][i] = configuration.function.Activate(structdata[1][i]);
            }
        }
    }
}
