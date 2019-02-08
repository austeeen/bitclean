using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace bitmapproto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void load_click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFD = new OpenFileDialog())
            {
                // File dialog settings
                openFD.Title = "Select an image file";
                openFD.InitialDirectory = "C:\\Users\\100057822\\Desktop";
                openFD.Filter = "bmp files (*.bmp)|*.bmp";
                openFD.RestoreDirectory = true;

                DialogResult result = openFD.ShowDialog();

                if (result == DialogResult.OK)
                    bmppath = openFD.FileName;

                try {
                    bmp = new Bitmap(Image.FromFile(bmppath));
                    pictureBox1.Image = bmp;
                }
                catch(Exception)
                { }
               
            }
        }

        private void fun_click(object sender, EventArgs e)
        {
            if (bmp == null) return;

            Color floor = Color.FromArgb(255, 0, 255);
            Color floorchange = Color.FromArgb(255, 255, 255);

            int low       = coltoi(Color.FromArgb(0, 0, 255));
            int lowmed    = coltoi(Color.FromArgb(0, 255, 255));
            int med       = coltoi(Color.FromArgb(0, 255, 0));
            int medhigh   = coltoi(Color.FromArgb(255, 255, 0));
            int high      = coltoi(Color.FromArgb(255, 0, 0));

            //string csvheader = "x, int";
            //StreamWriter csv = new StreamWriter(Path.GetDirectoryName(bmppath) + "\\" + Path.GetFileNameWithoutExtension(bmppath) + ".csv");

            //csv.WriteLine(csvheader);

            // Loop through the images pixels to reset color.
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color pixel = bmp.GetPixel(x, y);

                    if (pixel == floor)
                        bmp.SetPixel(x, y, floorchange);
                    
                    //Console.WriteLine(coltoi(bmp.GetPixel(x, y)));
                    //csv.WriteLine(x + "," + coltoi(bmp.GetPixel(x, y)));

                }
            }

            //csv.Close();

            pictureBox1.Image = bmp;
        }

        private void save_click(object sender, EventArgs e)
        {
            // Get the file's save name
            SaveFileDialog saveFD = new SaveFileDialog();

            saveFD.Title = "Save the image file";
            saveFD.Filter = "bmp files (*.bmp)|*.bmp";

            saveFD.FileName = Path.GetFileNameWithoutExtension(bmppath);

            saveFD.InitialDirectory = Path.GetDirectoryName(bmppath);

            DialogResult result = saveFD.ShowDialog();

            if (result == DialogResult.OK)
                bmp.Save(saveFD.FileName);
            else
                MessageBox.Show("File was not saved.", "File Not Saved", 0);
        }

        private int coltoi(Color pixel)
        {
            int numcolor = 0;
            int greenShift = 510;

            if (pixel.R == 255)
                numcolor = pixel.R + (255 - pixel.G) + pixel.B + greenShift;
            else if (pixel.G == 255)
                numcolor = pixel.R + pixel.G + (255 - pixel.B);
            else
                numcolor = pixel.R + pixel.G + pixel.B - 255;

            return numcolor;

        }

        public Bitmap bmp = null;
        public string bmppath = "";
    }
}
