using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/*
 * bitmapProto: BitClean/toolbox.cs
 * Author: Austin Herman
 * 2/11/2019
 */

namespace BitClean
{
	static class Constants
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

	public struct PixelDiagnosticsProperties
	{
		public bool includeWhite;
		public bool indexes;
		public bool integerValues;
		public bool RGBValues;
	};
	public struct ConfidenceDiagnosticsProperties
	{
		public bool objectdecision;
		public bool totalsize;
		public bool averagehue;
		public bool valuedensity;
		public bool edgeratio;
	};


	//the .pgm file's basic data
	public struct Data
    {
        public int width, height;
        public int totalpixels;
    };

    //a basic pixel class
    public struct Pixel
    {
        public bool selected;   //used for selection
        public short value;     //converted color integer value
		public byte r, g, b;
        public int id;          //ID [0->totalpixels]
    };

	public struct Coordinate
	{
		public int x, y;
	}

    //each pixel has eight neighbors
    class Octan
    {
        public int tl = -1, t = -1, tr = -1,
                   l = -1,          r = -1,
                   bl = -1, b = -1, br = -1;

        public Octan()
        {
            tl = -1; t = -1; tr = -1;
            l = -1;          r = -1;
            bl = -1; b = -1; br = -1;
        }
    };

    //edge and filler use this for navigation around the pixel map
    enum Direction
    {
        none, up, down, left, right
    };

    class Trail
    {
        public Direction dir = Direction.none;
        public int id = -1;
        public Trail(Direction d, int i) { dir = d; id = i; }
    };

	public struct ObjectBounds
	{
		public int top, left, bottom, right;
	}

    public class ObjectData
    {
		public int tag;             // unique id associated with object
		public double avghue;		// average integer color value of all pixels in selection
		public double density;		// percentage of non-floor colored pixels occupying the selection
		public int size;			// total size in pixels of selection
		public double edgeratio;	// ratio of total size to calculated edges
		public ObjectBounds bounds; // integer coordinate of top,left,bottom,right most pixels
		public Coordinate position;	// x,y coordinate of top-left most pixel
		public List<int> neighbors; // list of tags of other objects in the vicinity of this one
        public Confidence objconf;	// confidence property
    }

    public class Confidence
	{
        public double structure, dust,
                        s_size, d_size,
                        s_edge = 0.0, d_edge = 0.0,
                        s_val = 0.0, d_val = 0.0;
        public bool isStructure;
    };

    public class Node
    {
        public Node left, right;
        public int id;
        public Node() { left = null; right = null; id = -1; }
        public Node(int i) { left = null; right = null; id = i; }
    };

    //simply stores two integers in one structure
    class Tup
    {
        public int s, e;
        public Tup(int st, int en) { s = st; e = en; }
        public void Change(int st, int en) { s = st; e = en; }
    };

    public enum Field
    {
        tl, t, tr,
        l,      r,
        bl, b, br
    };

    public static class FieldVector
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