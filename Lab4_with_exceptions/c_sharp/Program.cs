using System;

namespace lab4_sharp
{
    struct Coord
    {
        public float x;
        public float y;
    };

    class Program
    {
        static void Main(string[] args)
        {
          //  Coord A = new Coord{ x=-4, y=0 }; Coord B = new Coord { x = 0, y = 6 }; Coord C = new Coord { x = 4, y = 0 }; Coord D = new Coord { x = 0, y = -6 };
            Coord A = new Coord { x = -1, y = 0 }; Coord B = new Coord { x = 0, y = 1 }; Coord C = new Coord { x = 0, y = 0 }; Coord D = new Coord { x = 1, y = -6 };
            try
            {
                Rhombus P1 = new Rhombus();
                Rhombus P2 = new Rhombus(A, B, C, D);
                Rhombus P3 = new Rhombus(P2);
                P3 = P3 * 2;//*0
                P1 = P3 - P2;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(ArithmeticException ex)
            {
                Console.WriteLine(ex.Message);
            }
			
		}
    }
}






