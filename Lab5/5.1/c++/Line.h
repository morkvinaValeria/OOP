#pragma once
struct Coord
{
    float x;
    float y;
};

class Line
{
protected:
    Coord start, end;
public:
    Line(Coord start, Coord end);
    float Length();
};

