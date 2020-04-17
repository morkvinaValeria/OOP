#include <iostream>
#include "MyString.h"
#include "DigitalString.h"
#include "LowerCaseString.h"

int main()
{
   MyString *a = new DigitalString("werty1234asdf");
   cout << a->Shift() << endl;
   cout << a->GetLength() << endl;
   MyString *b = new LowerCaseString("PWEsdfg234A");
    cout << b->Shift()<<endl;
    cout << b->GetLength()<<endl;
}