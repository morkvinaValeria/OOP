using System;

namespace OOP_lab5
{
    public struct Coord
    {
        public float x;
        public float y;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Coord coord1,coord2; coord1.x = 0; coord1.y = 0; coord2.x = 0; coord2.y = 100;
            Segment a = new Segment(coord1,coord2);
            coord1 = a.GetStartCoords(); coord2 = a.GetEndCoords();Console.WriteLine("(" + coord1.x + "," + coord1.y + "),"+ "(" + coord2.x + "," + coord2.y + ")");
           
            Console.WriteLine("Length = " + a.Length()+'\n');
            a.CuttingSegment();
            Console.WriteLine("After cutting: ");
            coord1 = a.GetStartCoords(); coord2 = a.GetEndCoords(); Console.WriteLine("(" + coord1.x + "," + coord1.y + ")," + "(" + coord2.x + "," + coord2.y + ")");
            Console.WriteLine("Length = " + a.Length());
        }
    }
}
