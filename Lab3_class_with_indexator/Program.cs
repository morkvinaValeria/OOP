using System;
using System.Text;

namespace Lab3
{
  
    class Program
    {
        static void Main(string[] args)
        {
             char[,] matrix = new char[6, 6]
             { {'a','b','c','d','e','f' },
             { 'a','w','c','d','i','g'},
             {'a','u','c','d','e','k' },
             { 'a','b','y','d','e','r'},
             { 'a','b','o','d','e','f'},
             { 'a','p','c','d','e','f'} };
            
            Letters symbols = new Letters();
            symbols.set(matrix);
            symbols.text_output();
            Console.WriteLine($"Третья строка массива: { symbols[2]}");
            Console.WriteLine($"Кол-во согласных букв в массиве: {symbols.ConsonantsCount}");

        }
    }
}
