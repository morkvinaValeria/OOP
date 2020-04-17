using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_lab5
{
    public class Segment : Line
    {
        public Segment(Coord start, Coord end): base(start,end){ }

        public void CuttingSegment()
        {
            end.x = end.x - 5*((end.x-start.x)/Length());
            end.y = end.y - 5 * ((end.y - start.y) / Length());
        }

        public Coord GetStartCoords()=> start;
        public Coord GetEndCoords() => end;
    }
}

