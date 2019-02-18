using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * bitmapProto: BitClean/image.cs
 * Author: Austin Herman
 * 2/11/2019
 */

namespace BitClean
{
    public class selection
    {
        selection()
        {
            Console.Write(selection_err + "initialized without pixels\n");
        }

        public selection(pixel[] pixels, int width, int total)
        {
            buffer = new List<int>();
            perimeter = new List<int>();
            p = pixels;
            this.width = width;
            this.total = total;
            buffersize = 0;
        }

        public bool get(int id)
        {
	        if (checkpixel(ref p[id])) // check the current pixel
	        {
		        iterate();

				/*
		        if (buffersize > 0 && buffersize < constants.MAX_OBJECT_SIZE_ESTIMATE)
		        {
			        fillpixels();
                    findedges();
			        return true;
		        }
				*/

				fillpixels();	// fill in any white pixels inside the selection
				findedges();	// find edge pixels in selection
				return true;
			}
	        return false;
        }

        private void iterate()
        {
            for (int i = 0; i < buffersize; i++)
                nextpixel(buffer[i]); // check neighbors for non-white
        }

        private void nextpixel(int id)
        {
            if ((id - width - 1) > 0)
            {
                checkpixel(ref p[id - width - 1]);   //top left
                checkpixel(ref p[id - width]);       //top center
                checkpixel(ref p[id - width + 1]);   //top right
            }

            if (id % width != 0)
                checkpixel(ref p[id - 1]);   //center left
            if (id % (width + 1) != 0)
                checkpixel(ref p[id + 1]);   //center right

            if ((id + width + 1) < total)
            {
                checkpixel(ref p[id + width - 1]);   //bottom left
                checkpixel(ref p[id + width]);       //bottom center
                checkpixel(ref p[id + width + 1]);   //bottom right
            }
        }

        private bool checkpixel(ref pixel p)
        {
            if (p.value != constants.INT_WHITE) 
            {
                if (!p.selected)
                {	// add pixel to buffer, make it selected, insert into buffer tree
                    buffer.Add(p.id); 
                    p.selected = true;
                    buffersize++;
                    tree.insert(ref buff, p.id);
                    return true;
				}// if not white and not selected
			}
            return false;
        }

        private void fillpixels()
        {
            filler fill = new filler(p, width, total);  // create fill object
			
			// run fill algorithm 
			// add any filled in pixels to the buffer and bump buffer size
			buffersize += fill.run(buffer, buffersize, buff);
        }

        private void findedges()
        {
            edge e = new edge(width, total);
            e.detect(buffer, buff);
            perimeter = e.getPerimiter();
            numedges = e.getEdges();
        }

        public void clearbuffer()
        {
            buffer.Clear();
            buffersize = 0;
            buff = null;
        }

        public int getedges()
        {
            return numedges;
        }

        public ref List<int> Buffer => ref buffer;

        public ref List<int> Perimeter => ref perimeter;

        private readonly pixel[] p;
        private readonly int width, total;
        private List<int> buffer, perimeter;
        private int buffersize, numedges;
        private node buff;
        private readonly string selection_err = "::SELECTION::error : ";
    }
}