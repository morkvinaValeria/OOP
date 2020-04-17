#include "Segment.h"

Segment::Segment(Coord start, Coord end) : Line(start, end) { }

void Segment::CuttingSegment()
{
    end.x = end.x - 5 * ((end.x - start.x) / Length());
    end.y = end.y - 5 * ((end.y - start.y) / Length());
}
Coord Segment::GetStartCoords() 
{ return start; }
Coord Segment::GetEndCoords() 
{ return end; }