#include <iostream>
#include "Line.h"
#include"Segment.h"
using namespace std;
int main()
{
	Coord o,w;
	Segment a = Segment({ 0,0 }, {0,100});
	o = a.GetStartCoords(); w = a.GetEndCoords();
	cout << "(" << o.x<<","<<o.y<<"),("<<w.x<<","<<w.y<<")"<<endl;
	cout <<"Length: "<< a.Length()<<endl;

	cout << "\n After cutting: \n";
	a.CuttingSegment();
	o = a.GetStartCoords(); w = a.GetEndCoords();
	cout << "(" << o.x << "," << o.y << "),(" << w.x << "," << w.y << ")" << endl;
	cout << "Length: " << a.Length() << endl;
}
