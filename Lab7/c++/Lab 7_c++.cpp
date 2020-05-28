#include <iostream>
#include "MyList.h"
using namespace std;

int main()
{
    MyList lst = MyList(); //Объявляем переменную, тип которой есть список
    Node b,c,d,e,k;
    long arr[10];
    b.value = 10; c.value = 2; d.value = 90; e.value = 30; k.value = 25;
    lst.AddNode(&b); //Добавляем в список элементы
    lst.AddNode(&c);
    lst.AddNode(&d);
    lst.AddNode(&e);
    lst.AddNode(&k);
    lst.ElementsMultiplicity5();
    lst.DeleteMoreThanAverage();
}
