#pragma once
#include "Line.h"

class Segment:public Line
{
public:
    Segment(Coord start, Coord end);
    void CuttingSegment();
    Coord GetStartCoords();
    Coord GetEndCoords();
};

