using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;

/*
 * bitclean: MainWindow.cs
 * Author: Austin Herman
 * 2/13/2019
 * MainWindow holds the main routines for the mainpage of this application.
 */

namespace BitClean
{
	public partial class MainWindow : Form
	{
		public Bitmap bmp;		// image represented as a bitmap
		private Pixel[] pixels;		// array of pixels in the image
		private Toolbox tools;		// contains algorithms for cleaning the image
		private Manager filemanager;	// holds directory/filename information

		public MainWindow()
		{	// init
			InitializeComponent();
			StartUp();
		}

		public void StartUp()
		{	// disable unusable menu items on start up, set default status message, initialize the file manager
			saveImageMenuStripItem.Enabled	= false;
			bitCleanMenuStripItem.Enabled	= false;
			exportMenuStripItem.Enabled	= false;
			toolStripText.Text = ToolStripMessages.DEFAULT_MESSAGE;
			filemanager = new Manager();
		}

		#region File Drop Down Buttons
		//
		// File > Load
		//
		private void LoadImageFile_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFD = new OpenFileDialog())
			{
				// set dialog settings
				openFD.Title = "Select an image file";
				openFD.InitialDirectory = filemanager.ImageDirectory;
				openFD.Filter = "all files (*.*)|*.*";
				openFD.RestoreDirectory = true;

				// show dialog and it returned okay
				if (openFD.ShowDialog() == DialogResult.OK)
				{	
					// set path/image directory information
					filemanager.SetImageDirectory(Path.GetDirectoryName(openFD.FileName));
					filemanager.ImagePath = openFD.FileName;
				}

				try {
					// set status
					toolStripText.Text = ToolStripMessages.IMAGE_LOADING;
					statusStrip1.Refresh();

                    // load bmp
                    bmp = new Bitmap(Image.FromFile(filemanager.ImagePath));
                    // bmp = new Bitmap(filemanager.ImagePath, true);

					// switch magenta colored pixels (floor color from cloud compare) to white pixels,
					// and populate pixel array
					pictureBox1.Image = ImageOperations.ParseImage(bmp, ref pixels);

					// create toolbox for cleaning systems
					tools = new Toolbox(pixels, new Data {
											totalpixels = bmp.Height * bmp.Width,
											height = bmp.Height,
											width = bmp.Width } );
					
					// enable bitclean and save image menu items
					bitCleanMenuStripItem.Enabled	= true;
					saveImageMenuStripItem.Enabled	= true;
					// disable export diagnostics until image is cleaned
					exportMenuStripItem.Enabled =	 false;
					toolStripText.Text = ToolStripMessages.IMAGE_LOADED;

				}
				catch (Exception excep) { // run load image process
					toolStripText.Text = ToolStripMessages.IMAGE_LOAD_FAILED;
                    Console.WriteLine(excep.Message);
                    Console.WriteLine(excep.StackTrace);
					bmp = null;
				}
			}

            /* TESTING COLTOI
            Bitmap testbmp = new Bitmap(765, 1);

            int r = 0, g = 0, b = 255;

            for (int y = 0; y < testbmp.Height; y++)
            {
                for (int x = 0; x < testbmp.Width; x++)
                {
                    Color c = Color.FromArgb(r, g, b);
                    testbmp.SetPixel(x, y, c);
                    Console.WriteLine("coltoi: {0}", ImageOperations.ColToInt(c));
                   
                    if(r == 0)
                    {
                        b--;
                        g++;

                        if(b < 0)
                            b = 0;

                        if (g > 255) { 
                            g = 255;
                            r = 1;
                        }
                    }
                    else if(g == 255 && r < 255)
                    {
                        r++;
                        if (r > 255)
                            r = 255;
                    }
                    else if(r == 255)
                    {
                        g--;
                        if (g < 0)
                            g = 0;
                    }
                }
            }

            pictureBox1.Image = testbmp;
            */           

        }
		//
		// File > Save
		//
		private void SaveImageFile_Click(object sender, EventArgs e)
		{
			if (bmp != null)
            {
                SaveFileDialog saveFD = new SaveFileDialog
                {

                    // set up file dialog
                    Title = "Save the image file",
                    Filter = "bmp files (*.bmp)|*.bmp",
                    FileName = Path.GetFileNameWithoutExtension(filemanager.ImagePath),
                    InitialDirectory = Path.GetDirectoryName(filemanager.ImageDirectory)
                };

                // if dialog returned ok
                if (saveFD.ShowDialog() == DialogResult.OK) {
					// save bmp, set status
					bmp.Save(saveFD.FileName);
					toolStripText.Text = ToolStripMessages.IMAGE_SAVED;
				}
				else {
					// dialog failed, set status
					toolStripText.Text = ToolStripMessages.IMAGE_SAVE_FAILED;
					MessageBox.Show("File was not saved.", "File Not Saved", 0);
				}
					
			}
			else {
				toolStripText.Text = ToolStripMessages.IMAGE_SAVE_FAILED;
				MessageBox.Show("no image loaded!");
			}
		}
		#endregion

		#region Image Drop Down Buttons
		//
		// Image > Bit Clean
		//
		private void BitCleanImage_Click(object sender, EventArgs e)
		{
			if (tools != null)
			{
				// set status to cleaning
				toolStripText.Text = ToolStripMessages.CLEANING_IMAGE;
				statusStrip1.Refresh();

                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();

                watch.Start();

				// run tools to clean
				tools.Run(progressBar, statusStrip1, toolStripText);

                watch.Stop();

                string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}",
                        watch.Elapsed.Minutes, watch.Elapsed.Seconds,
                        watch.Elapsed.Milliseconds / 10);

                Console.WriteLine("watch: " + elapsedTime);

                // update pixels and image display
                ImageOperations.PushPixelsToImage(bmp, pixels);
				pictureBox1.Image = bmp;

				// enable export diagnostics
				exportMenuStripItem.Enabled = true;

				// set status done
				MessageBox.Show("done");
				toolStripText.Text = ToolStripMessages.IMAGE_CLEANED;
			}
			else
				MessageBox.Show("no image loaded!");
		}
		#endregion

		#region Diagnostics Drop Down Buttons
		//
		// Diagnostics > Export to XMLDiagnostics
		//
		private void ExportDiagnostics_Click(object sender, EventArgs e)
		{
			List<ObjectData> objectdata = tools.GetObjectData();

			// write all data into xml file format
			using (var saveFD = new SaveFileDialog())
			{
				// set up file dialog
				saveFD.Title = "Save the diagostics xml file";
				saveFD.Filter = "xml files (*.xml)|*.xml";
				saveFD.FileName = Path.GetFileNameWithoutExtension(filemanager.ImagePath + "data");
				saveFD.InitialDirectory = filemanager.XMLDirectory;

				// dialog successful
				if (saveFD.ShowDialog() == DialogResult.OK)
				{
					// update file manager
					filemanager.SetXMLDirectory(Path.GetDirectoryName(saveFD.FileName));

					// create xml document, add objects root
					var xml = new XDocument();
					var root = new XElement("objects");
					xml.Add(root);

					// for each object found
					for (int i = 0; i < objectdata.Count; i++)
					{
						ObjectData obj = objectdata[i];

						// create object entry and it's attributes
						var objectElement = new XElement("object");
						objectElement.SetAttributeValue("tag", obj.tag);
						objectElement.SetAttributeValue("decision", obj.objconf.decision);

						// create object's attributes
						var sizeElement		= new XElement("size", obj.size);
						var avgHueElement	= new XElement("avg_hue", obj.avghue);
						var densityElement	= new XElement("density", obj.density);
						var edgeRatioElement = new XElement("edge_ratio", obj.edgeratio);

						var boundsElement	= new XElement("bounds");
						var topElement		= new XElement("top", obj.bounds.top);
						var leftElement		= new XElement("left", obj.bounds.left);
						var bottomElement	= new XElement("bottom", obj.bounds.bottom);
						var rightElement	= new XElement("right", obj.bounds.right);
						boundsElement.Add(topElement);
						boundsElement.Add(leftElement);
						boundsElement.Add(bottomElement);
						boundsElement.Add(rightElement);

						var coordinatesElement = new XElement("coordinates");
						var xElement = new XElement("x", obj.position.x);
						var yElement = new XElement("y", obj.position.y);
						coordinatesElement.Add(xElement);
						coordinatesElement.Add(yElement);

						var neighborsElement = new XElement("neighbors");
						neighborsElement.SetAttributeValue("total", obj.neighbors.Count);

						for (int j = 0; j < obj.neighbors.Count; j++) {
							var neighborTagElement = new XElement("tag", obj.neighbors[j]);
							neighborsElement.Add(neighborTagElement);
						}

						// add attributes to the object
						objectElement.Add(sizeElement);
						objectElement.Add(avgHueElement);
						objectElement.Add(densityElement);
						objectElement.Add(edgeRatioElement);
						objectElement.Add(boundsElement);
						objectElement.Add(coordinatesElement);
						objectElement.Add(neighborsElement);

						// add object to objects root node
						root.Add(objectElement);
					}

					// save xml file, set status
					xml.Save(saveFD.FileName);
					toolStripText.Text = ToolStripMessages.XML_DATA_EXPORTED;
				}
				else {
					toolStripText.Text = ToolStripMessages.XML_EXPORT_FAILED;
					MessageBox.Show("export failed");
				}
					
			}

		}
		//
		// Diagnostics > View Diagnostics Window
		//
		private void Plots_Click(object sender, EventArgs e)
		{
            try {
                // create/show new diagnostics window
                Diagnostics diagnosticsWindow = new Diagnostics(filemanager);
                diagnosticsWindow.Show();
            }
            catch(Exception excep) {
                Console.Write(excep.Message);
            }

        }
		#endregion
	}
}
