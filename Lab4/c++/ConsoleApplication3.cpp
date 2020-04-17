#include <iostream>
#include<iomanip>
#include"Rhombus.h"
using namespace std;


int main()
{
	Rhombus P1 = Rhombus();
	Rhombus P2 = Rhombus({ -4, 0 }, { 0, 6 }, { 4, 0 }, { 0, -6 });
	Rhombus P3 = Rhombus(P2);

	cout << "Rhombus P1: (" << P1.getCoordinate(1).X << "," << P1.getCoordinate(1).Y << "),(" << P1.getCoordinate(2).X << "," << P1.getCoordinate(2).Y << "),(" << P1.getCoordinate(3).X << "," << P1.getCoordinate(3).Y << "),(" << P1.getCoordinate(4).X << "," << P1.getCoordinate(4).Y<<")  |  ";
	cout << "Rhombus P2: (" << P2.getCoordinate(1).X << "," << P2.getCoordinate(1).Y << "),(" << P2.getCoordinate(2).X << "," << P2.getCoordinate(2).Y << "),(" << P2.getCoordinate(3).X << "," << P2.getCoordinate(3).Y << "),(" << P2.getCoordinate(4).X << "," << P2.getCoordinate(4).Y << ")  |  ";
	cout << "Rhombus P3: (" << P3.getCoordinate(1).X << "," << P3.getCoordinate(1).Y << "),(" << P3.getCoordinate(2).X << "," << P3.getCoordinate(2).Y << "),(" << P3.getCoordinate(3).X << "," << P3.getCoordinate(3).Y << "),(" << P3.getCoordinate(4).X << "," << P3.getCoordinate(4).Y << ")"<<setw(21);
	
	cout << "Side = " << P1.Length({ P1.getCoordinate(1).X,P1.getCoordinate(1).Y }, { P1.getCoordinate(2).X,P1.getCoordinate(2).Y })<<setw(17)<<"|"<<setw(22);
	cout << "Side = " << P2.Length({ P2.getCoordinate(1).X,P2.getCoordinate(1).Y }, { P2.getCoordinate(2).X,P2.getCoordinate(2).Y }) << setw(14) << "|" << setw(22);
	cout << "Side = " << P3.Length({ P3.getCoordinate(1).X,P3.getCoordinate(1).Y }, { P3.getCoordinate(2).X,P3.getCoordinate(2).Y }) <<setw(29);
	
	cout << "P = " << P1.Perimeter() << ", S = " << P1.Square() <<setw(13)<< "|"<<setw(19);
    cout << "P = " << P2.Perimeter() << ", S = " << P2.Square() <<setw(8)<<"|"<<setw(19);
	cout << "P = " << P3.Perimeter() << ", S = " << P3.Square() << endl << endl<<endl;

	P3 = P3*2;
	cout << "After double the rhombus P3:" << endl;
	cout << "Rhombus P3: (" << P3.getCoordinate(1).X << "," << P3.getCoordinate(1).Y << "),(" << P3.getCoordinate(2).X << "," << P3.getCoordinate(2).Y << "),(" << P3.getCoordinate(3).X << "," << P3.getCoordinate(3).Y << "),(" << P3.getCoordinate(4).X << "," << P3.getCoordinate(4).Y << ")" << endl<<setw(20);
	cout << "Side = " << P3.Length({ P3.getCoordinate(1).X,P3.getCoordinate(1).Y }, { P3.getCoordinate(2).X,P3.getCoordinate(2).Y }) << endl<<setw(17);
	cout << "P = " << P3.Perimeter() << ", S = " << P3.Square() << endl<<endl << endl;

	cout << "After P1=P3-P2: " << endl;
	P1 = P3 - P2;
	cout << "Rhombus P1: (" << P1.getCoordinate(1).X << "," << P1.getCoordinate(1).Y << "),(" << P1.getCoordinate(2).X << "," << P1.getCoordinate(2).Y << "),(" << P1.getCoordinate(3).X << "," << P1.getCoordinate(3).Y << "),(" << P1.getCoordinate(4).X << "," << P1.getCoordinate(4).Y << ")"<<endl<<setw(20);
	cout << "Side = " << P1.Length({ P1.getCoordinate(1).X,P1.getCoordinate(1).Y }, { P1.getCoordinate(2).X,P1.getCoordinate(2).Y }) << endl<< setw(17);
	cout << "P = " << P1.Perimeter() << ", S = " << P1.Square() << endl<<endl;
}
