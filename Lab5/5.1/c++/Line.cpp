#include "Line.h"
#include <iostream>

Line :: Line(Coord start, Coord end)
{
    this->start = start;
    this->end = end;
}

float Line:: Length()
{
    return float(sqrt(pow(end.x - start.x, 2) + pow(end.y - start.y, 2)));
}