using System;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Expression[] exp = new Expression[2];
                exp[0] = new Expression(2, 0, -8, 1);
                exp[1] = new Expression(1, 2, 3, 4);
               /* exp[1].a = 1; exp[1].b = 2;
                exp[1].c = 3; exp[1].d = 4;*/

                for (int i = 0; i < exp.Length; i++)
                       exp[i].Calculate();
            }
            catch(DivideByZeroException ex)
            {
               Console.WriteLine( ex.Message);
            }
            catch(ArithmeticException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
