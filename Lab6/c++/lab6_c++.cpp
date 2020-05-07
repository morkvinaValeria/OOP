#include"Expression.h"
#include <iostream>

int main()
{
    try
    {
        const int  n = 2;
        Expression exp [n];
        exp[0] = Expression(2, 0, -8, 1);
        exp[1] = Expression(1, 2, 3, 4);
        /* exp[1].a = 1; exp[1].b = 2;
         exp[1].c = 3; exp[1].d = 4;*/
       
        for (int i = 0; i < n; i++)
            exp[i].Calculate();
    }
    catch (invalid_argument ex)
    {
        cout << ex.what()<<endl;
    }
    catch (logic_error ex)
    {
        cout << ex.what()<<endl;
    }
}

