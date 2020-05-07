#include <iostream>
#include<iomanip>
#include"Rhombus.h"

using namespace std;


int main()
{
	try 
	{
		Rhombus P1 = Rhombus();
		Rhombus P2 = Rhombus({ -4, 0 }, { 0, 6 }, { 4, 0 }, { 0, -6 });
		//Rhombus P2 = Rhombus({ -1, 0 }, { 0, 1 }, { 4, 20 }, { 30, -6 });
		Rhombus P3 = Rhombus(P2);

		P3 = P3 * 2;//*0;
		P1 = P3 - P2;
	}
	catch(invalid_argument ex)
	{
		cout << ex.what() << endl;
	}
	catch (logic_error ex)
	{
		cout << ex.what() << endl;
	}
}
