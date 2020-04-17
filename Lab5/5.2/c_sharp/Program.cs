using System;

namespace lab5._2_cSharp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            MyString a = new DigitalString("223hg/2ertyu65");
            Console.WriteLine(a.Shift());
            Console.WriteLine(a.GetLength());

            MyString b = new LowerCaseString("AdT123vvV###");
            Console.WriteLine( b.Shift());
            Console.WriteLine(b.GetLength());
        }
    }
}
