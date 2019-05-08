using System;
using Gtk;
using Gdk;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

/// <summary>
/// Main window. Holds main routines
/// </summary>
public partial class MainWindow : Gtk.Window
{
    Bitmap bitmap;
    List<bitclean.ObjectData> objects;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    /// <summary>
    /// Loads and displays an image.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">E.</param>
    protected void LoadImage(object sender, EventArgs e)
    {
        // get file path from user
        string result = null;
        Gtk.FileChooserDialog openDialog = new Gtk.FileChooserDialog("Open", null, Gtk.FileChooserAction.Open, "Cancel", Gtk.ResponseType.Cancel, "Open", Gtk.ResponseType.Accept);


        if (openDialog.Run() == (int)Gtk.ResponseType.Accept)
        {
            result = openDialog.Filename;

            // load and display image
            try {
                Pixbuf buffer = new Pixbuf(result);
                displayedImage.Pixbuf = buffer;

                //open image as a bitmap and parse it to change the floor color
                bitmap = new Bitmap(result);
                bitclean.ImageOperations.ParseImage(ref bitmap);
            } catch(Exception excp) {
                Console.WriteLine(excp.Message);
            }

        }

        openDialog.Destroy();
    }

    /// <summary>
    /// Saves the image to a valid image file type of jpeg, png, bmp, or ico.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">E.</param>
    protected void SaveImage(object sender, EventArgs e)
    {
        // get file path from user
        string result = null;
        Gtk.FileChooserDialog saveDialog = new Gtk.FileChooserDialog("Save as", null, Gtk.FileChooserAction.Save, "Cancel", Gtk.ResponseType.Cancel, "Save", Gtk.ResponseType.Accept);

        if (saveDialog.Run() == (int)Gtk.ResponseType.Accept)
        {
            // get extension
            result = saveDialog.Filename;
            string extension = System.IO.Path.GetExtension(result);

            try { // try to save file
                if (!displayedImage.Pixbuf.Save(result, extension.Substring(1)))
                    Console.WriteLine("cannot save file extension {0}", extension);
            } catch(Exception excp) {
                Console.WriteLine(excp.Message);
            }
        }

        saveDialog.Destroy();
    }

    /// <summary>
    /// Runs bitclean.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">E.</param>
    protected void RunBitclean(object sender, EventArgs e)
    {
        // set up data structures for toolbox
        bitclean.Data imgdata;
        imgdata.height = displayedImage.Pixbuf.Height;
        imgdata.width = displayedImage.Pixbuf.Width;
        imgdata.totalpixels = imgdata.height * imgdata.width;

        bitclean.Pixel[] pixels;
        pixels = new bitclean.Pixel[imgdata.totalpixels];
        bitclean.ImageOperations.PopulatePixelArray(bitmap, ref pixels);

        // create toolbox
        bitclean.Toolbox toolbox = new bitclean.Toolbox(pixels, imgdata);

        // run toolbox
        toolbox.Run();

        // get object data from toolbox
        objects = toolbox.GetObjectData();

        // update displayed image
        bitclean.ImageOperations.PushPixelsToImage(bitmap, pixels);

        MemoryStream newpixelstream = new MemoryStream();
        bitmap.Save(newpixelstream, System.Drawing.Imaging.ImageFormat.Png);

        newpixelstream.Seek(0, SeekOrigin.Begin);
        displayedImage.Pixbuf = new Pixbuf(newpixelstream);
    }

    /// <summary>
    /// Exports data returned from bitclean to xml.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">E.</param>
    protected void ExportToXML(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// Opens the diagnostics window.
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">E.</param>
    protected void OpenDiagnostics(object sender, EventArgs e)
    {
    }

}
