using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/*
 * bitmapProto: bitclean/toolbox.cs
 * Author: Austin Herman
 * 2/11/2019
 */

namespace bitmapproto
{
	static class constants
	{
		public const short VALUE_THRESHOLD = 0;                             // a useful threshold for pixel values (white)
		public const int MAX_OBJECT_SIZE_ESTIMATE = 2700;                   // if an object is bigger than this ignore it -- optimization thing
		public const int COLOR_CLEAR = 0;                                   // color to clear selections with
		public const int BRUSH_SIZE = 16;                                   // brush size for trajectory path
		public static readonly Color FLOOR = Color.FromArgb(255, 0, 255);   // this is magenta - what the floor looks like from cloud compare
		public static readonly Color WHITE = Color.FromArgb(255, 255, 255); // white color - what we want to change the floor to
		public const short INT_WHITE = 0;                                   // white color can be represented as 0 because color values run [1->1021]
																			//  - this is helpful for average hue and average density functions
	}

	enum DIAGNOSTICS
	{
		ALL, NON_WHITE
	};

	//the .pgm file's basic data
	public struct data
    {
        public int width, height;
        public int totalpixels;
    };

    //a basic pixel class
    public struct pixel
    {
        public bool selected;   //used for selection
        public short value;     //converted color integer value
		public byte r, g, b;
        public int id;          //ID [0->totalpixels]
    };

    //each pixel has eight neighbors
    class octan
    {
        public int tl = -1, t = -1, tr = -1,
                   l = -1,          r = -1,
                   bl = -1, b = -1, br = -1;

        public octan()
        {
            tl = -1; t = -1; tr = -1;
            l = -1;          r = -1;
            bl = -1; b = -1; br = -1;
        }
    };

    //edge and filler use this for navigation around the pixel map
    enum direction
    {
        none, up, down, left, right
    };

    class path
    {
        public direction dir = direction.none;
        public int id = -1;
        public path(direction d, int i) { dir = d; id = i; }
    };

    public class objectData
    {
        public objectData(double av, int s, double e)
        {
            avgval = av;
            size = s;
            edgeratio = e;
        }

        public double avgval;
        public int size;
        public double edgeratio;
        public conf objconf;
    }

    public class conf
    {
        public double structure = 0.0, dust = 0.0,
                        s_size = 0.0, d_size = 0.0,
                        s_edge = 0.0, d_edge = 0.0,
                        s_val = 0.0, d_val = 0.0;
        public bool isStructure;
    };

    public class node
    {
        public node left, right;
        public int id;
        public node() { left = null; right = null; id = -1; }
        public node(int i) { left = null; right = null; id = i; }
    };

    //simply stores two integers in one structure
    class tup
    {
        public int s, e;
        public tup(int st, int en) { s = st; e = en; }
        public void change(int st, int en) { s = st; e = en; }
    };

    public enum field
    {
        tl, t, tr,
        l,      r,
        bl, b, br
    };

    public static class fieldvector
    {
        public static readonly int[] verticalfield =
        {
            -1, 0, 1,
            -2,    2,
            -1, 0, 1
        };
        public static readonly int[] horizontalfield =
        {
            -1, -2, -1,
             0,      0,
             1,  2,  1
        };
        public static readonly int[] leftslantfield =
        {
            0, -1, -2,
            1,     -1,
            2,  1,  0
        };
        public static readonly int[] rightslantfield =
        {
            -2, -1, 0,
            -1,     1,
             0,  1, 2
        };
    }

}