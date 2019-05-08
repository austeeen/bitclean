using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace bitclean
{
    public partial class Diagnostics : Gtk.Window
    {

        Gtk.ListStore store = new Gtk.ListStore(
        typeof(int), typeof(string), typeof(int), 
        typeof(double), typeof(double), typeof(double), 
        typeof(int), typeof(double));

        List<ChartObject> objects;

        public Diagnostics() : base(Gtk.WindowType.Toplevel)
        {
            Build();

            objects = new List<ChartObject>();

            // tag, decision, size, avghue, density, edgeratio, neighbors.count
            datatree.AppendColumn("Tag", new Gtk.CellRendererText(), "text", 0);
            datatree.AppendColumn("Decision", new Gtk.CellRendererText(), "text", 1);
            datatree.AppendColumn("Size", new Gtk.CellRendererText(), "text", 2);
            datatree.AppendColumn("Avghue", new Gtk.CellRendererText(), "text", 3);
            datatree.AppendColumn("Density", new Gtk.CellRendererText(), "text", 4);
            datatree.AppendColumn("Edgeratio", new Gtk.CellRendererText(), "text", 5);
            datatree.AppendColumn("Neighbors", new Gtk.CellRendererText(), "text", 6);
            datatree.AppendColumn("Neural Output", new Gtk.CellRendererText(), "text", 7);

            datatree.Model = store;

            datatree.ShowAll();
        }

        protected void LoadXMLData(object sender, EventArgs e)
        {
            // clear any data already in the tree store
            if (store.Data.Count != 0) {
                store.Data.Clear();
                store.Clear();
                datatree.Show();
            }

            // get file from user
            string result = null;
            Gtk.FileChooserDialog openDialog = new Gtk.FileChooserDialog("Open", null, Gtk.FileChooserAction.Open, "Cancel", Gtk.ResponseType.Cancel, "Open", Gtk.ResponseType.Accept);
            Gtk.FileFilter xmlFilter = new Gtk.FileFilter { Name = "xml" };
            xmlFilter.AddPattern("*.xml");
            openDialog.AddFilter(xmlFilter);

            if (openDialog.Run() == (int)Gtk.ResponseType.Accept)
                result = openDialog.Filename;

            openDialog.Destroy();

            if (result != null)
            {
                try {
                    GetXMLData(result);
                } catch(Exception excp) {
                    Console.WriteLine(excp.Message);
                }

                if (objects.Count > 0)
                    PopulateTreeView();
            }

            datatree.ShowAll();
        }

        private void GetXMLData(string path)
        {
            if (objects.Count != 0)
                objects.Clear();

            // load xml doc and set it's root
            XElement doc = XDocument.Load(path).Root;

            // iterate through each object in root
            foreach (var obj in doc.Descendants("object"))
            {
                // create chart object and populate it's data with xml attributes
                ChartObject chartObject = new ChartObject
                {
                    tag = (int)obj.Attribute("tag"),
                    decision = (string)obj.Attribute("decision"),
                    size = (int)obj.Element("size"),
                    avghue = (double)obj.Element("avg_hue"),
                    density = (double)obj.Element("density"),
                    edgeratio = (double)obj.Element("edge_ratio"),

                    neighbors = new List<int>()
                };
                foreach (var neighbor in obj.Descendants("tag"))
                    chartObject.neighbors.Add((int)neighbor);

                // add chart object to object list
                objects.Add(chartObject);
            }

        }

        private void PopulateTreeView()
        {
            // add chart objects to chart display and get statistics on each chart object
            foreach (ChartObject obj in objects)
            {
                try {
                    store.AppendValues(obj.tag, obj.decision, obj.size, obj.avghue, obj.density, obj.edgeratio, obj.neighbors.Count, 0);
                } catch(Exception excp) {
                    Console.WriteLine(excp.Message);
                }
            }
        }
    }
}
