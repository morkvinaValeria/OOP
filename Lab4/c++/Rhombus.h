#pragma once
#include <iostream>
#include<iomanip>


struct COORD
{
	float X;
	float Y;
};

class Rhombus
{
private:
	COORD A, B , C , D ;

public:
	Rhombus();
	Rhombus(COORD A, COORD B, COORD C, COORD D);
	Rhombus(const Rhombus& ref_coord);
	float Length(COORD A, COORD B);
	float Square();
	float Perimeter();
	COORD getCoordinate(int point_number);
	friend Rhombus operator*(const Rhombus& v, int d);
	friend Rhombus operator-(const Rhombus& a, const Rhombus& b);
};