using System;

namespace Lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList lst = new MyList();
            lst.AddNode(new Node(20));
            lst.AddNode(new Node(90));
            lst.AddNode(new Node(10));
            lst.AddNode(new Node(65));
            Console.WriteLine(lst.ElementsMultiplicity5());
            lst.DeleteMoreThanAverage();
        }
    }
}
