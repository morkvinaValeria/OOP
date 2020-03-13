using System;

namespace Console_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] D = { 'n', 'o',' ','m','a','n',' ','i','s',' ','a','n',' ','i','s','l','a','n','d', '\n' };
            char[] V = { 'l', 'o', 'v', 'e', '\n' };

            MyLibrary.MyString A = new MyLibrary.MyString(D);
            MyLibrary.MyString B = new MyLibrary.MyString(V);

            MyLibrary.ContainerText literature = new MyLibrary.ContainerText();

            literature.add(A);
            literature.add(B);
            
            literature.remove(A);
           
            literature.clear();

            literature.add(B);
            literature.add(A);

            literature.touppercase();
           
            literature.string_nums_by_length(4);

            literature.getkeystring(0);
        }
    }
}
