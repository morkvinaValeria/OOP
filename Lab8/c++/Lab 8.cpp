#include <stdexcept>
#include <iostream>
#include <string>
using namespace std;

int LenRow(string** a)
{
    int i = 0;
    while (a[0][i] != "\0")
        i++;
    return i;
}
int LenCol(string** a)
{
    int j = 0;
    while (a[j][0] != "\0")
        j++;
    return j;
}

string* Get_MainDiagonal(string** a)
{
    if(LenRow(a)==0 && LenCol(a) == 0)
        throw invalid_argument("Array cannot be null");

    int n;
    if (LenRow(a) >= LenCol(a))
        n = LenCol(a);
    else
        n = LenRow(a);

    string* b = new string[n];
    for(int i = 0; i < LenRow(a); i++)
        for (int j = 0; j < LenCol(a); j++)
            if (i == j)
                b[i] = a[i][j];
    return b;
}


int main()
{
    int n = 5;
    string** a = new string* [n];
    for (int i = 0; i < 2; i++)
        a[i] = new string[n];
    a[0][0] = "w";  
    
    string*(*Ptr)(string**) = Get_MainDiagonal;
    try
    {
        Ptr(a);
    }
    catch (invalid_argument ex)
    {
        cout << ex.what();
    }
}