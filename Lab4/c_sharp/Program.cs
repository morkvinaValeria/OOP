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
			Coord A = new Coord{ x=-4, y=0 }; Coord B = new Coord { x = 0, y = 6 }; Coord C = new Coord { x = 4, y = 0 }; Coord D = new Coord { x = 0, y = -6 };
			
			Rhombus P1 = new Rhombus();
			Rhombus P2 = new Rhombus( A, B, C, D );
			Rhombus P3 = new Rhombus(P2);

			Console.Write( "Rhombus P1: (" + P1.GetCoordinate(1).x + "," + P1.GetCoordinate(1).y + "),(" + P1.GetCoordinate(2).x + "," + P1.GetCoordinate(2).y + "),(" + P1.GetCoordinate(3).x + "," + P1.GetCoordinate(3).y + "),(" + P1.GetCoordinate(4).x + "," + P1.GetCoordinate(4).y + ")     | ");
			Console.WriteLine("P = " + P1.Perimeter() + ", S = " + P1.Square());
			
			Console.Write("Rhombus P2: (" + P2.GetCoordinate(1).x + "," + P2.GetCoordinate(1).y + "),(" + P2.GetCoordinate(2).x + "," + P2.GetCoordinate(2).y + "),(" + P2.GetCoordinate(3).x + "," + P2.GetCoordinate(3).y + "),(" + P2.GetCoordinate(4).x + "," + P2.GetCoordinate(4).y + ")   | ");
			Console.WriteLine("P = " + P2.Perimeter() + ", S = " + P2.Square());
			
			Console.Write("Rhombus P3: (" + P3.GetCoordinate(1).x + "," + P3.GetCoordinate(1).y + "),(" + P3.GetCoordinate(2).x + "," + P3.GetCoordinate(2).y + "),(" + P3.GetCoordinate(3).x + "," + P3.GetCoordinate(3).y + "),(" + P3.GetCoordinate(4).x + "," + P3.GetCoordinate(4).y + ")   | ");
			Console.WriteLine("P = " + P3.Perimeter() + ", S = " + P3.Square()+"\n");
			

			P3 = P3 * 2;
			
			Console.WriteLine("After double the rhombus P3:");
			Console.Write("Rhombus P3: (" + P3.GetCoordinate(1).x + "," + P3.GetCoordinate(1).y + "),(" + P3.GetCoordinate(2).x + "," + P3.GetCoordinate(2).y + "),(" + P3.GetCoordinate(3).x + "," + P3.GetCoordinate(3).y + "),(" + P3.GetCoordinate(4).x + "," + P3.GetCoordinate(4).y + ") | ");
			Console.WriteLine("P = " + P3.Perimeter() + ", S = " + P3.Square()+"\n");


			P1 = P3 - P2;
			Console.WriteLine("After P1=P3-P2: ");
			Console.Write("Rhombus P1: (" + P1.GetCoordinate(1).x + "," + P1.GetCoordinate(1).y + "),(" + P1.GetCoordinate(2).x + "," + P1.GetCoordinate(2).y + "),(" + P1.GetCoordinate(3).x + "," + P1.GetCoordinate(3).y + "),(" + P1.GetCoordinate(4).x + "," + P1.GetCoordinate(4).y + ")   | ");
		    Console.WriteLine("P = " + P1.Perimeter() + ", S = " + P1.Square()+"\n"); 
		}
    }
}






