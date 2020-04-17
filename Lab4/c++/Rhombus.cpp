#include"Rhombus.h"

Rhombus::Rhombus() {}

Rhombus::Rhombus(COORD A, COORD B, COORD C, COORD D)
{
	this->A = A;
	this->B = B;
	this->C = C;
	this->D = D;
}

Rhombus::Rhombus(const Rhombus& coord)
{
	A = coord.A;
	B = coord.B;
	C = coord.C;
	D = coord.D;
}

float Rhombus:: Length(COORD A, COORD B)
{
	return sqrt(pow((B.X - A.X), 2) + pow((B.Y - A.Y), 2));
}

float Rhombus::Square()
{
	return (Length(A, C) * Length(B, D)) / 2;;
}

float Rhombus::Perimeter()
{
	return 4 * Length(A, B);
}

COORD Rhombus::getCoordinate(int point_number)
{
	return point_number == 1 ? A : point_number == 2 ? B : point_number == 3 ? C : D;
}



Rhombus operator*(const Rhombus& v, int d)
{
	Rhombus coord;
	coord.A.X = v.A.X * d;
	coord.A.Y = v.A.Y * d;
	coord.B.X = v.B.X * d;
	coord.B.Y = v.B.Y * d;
	coord.C.X = v.C.X * d;
	coord.C.Y = v.C.Y * d;
	coord.D.X = v.D.X * d;
	coord.D.Y = v.D.Y * d;
	return coord;
}
Rhombus operator-(const Rhombus& a, const Rhombus& b)
{
	Rhombus temp;
	temp.A.X = a.A.X - b.A.X;
	temp.A.Y = a.A.Y - b.A.Y;
	temp.B.X = a.B.X - b.B.X;
	temp.B.Y = a.B.Y - b.B.Y;
	temp.C.X = a.C.X - b.C.X;
	temp.C.Y = a.C.Y - b.C.Y;
	temp.D.X = a.D.X - b.D.X;
	temp.D.Y = a.D.Y - b.D.Y;
	return temp;
}
