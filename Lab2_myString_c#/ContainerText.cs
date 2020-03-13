using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class ContainerText
    {
        static int length = 5;
        MyString[] text = new MyString[length];
        int string_nums;
        public void add(MyString mystring)
        {
            if (text[length - 1] != null)
            {
                length = (3 * length) / 2 + 1;
                MyString[] newtext = new MyString[length];

                for (int i = 0; i < string_nums; i++)
                {
                    newtext[i] = text[i];
                }

                text = newtext;
            }
            text[string_nums] = mystring;
            string_nums++;
        }

        public void remove(MyString mystring)
        {
            int index = 0;
            int i = 0;
            while (i < string_nums && !mystring.equal(text[i]))
            {
                index = i;
                i++;
            }

            for (int j = index; j < string_nums; j++)
            {
                text[j] = text[j + 1];
            }
            text[string_nums] = null;
            string_nums--;
        }

        public void clear()
        {
            for (int i = 0; i < string_nums; i++)
            {
                text[i] = null;
            }
            string_nums = 0;
        }

        public void touppercase()
        {
            for (int i = 0; i < string_nums; i++)
            {
                text[i].toUpperCase();
            }
        }

        public char[] getkeystring(int index)
        {
            return text[index].getkey();
        }

        public int string_nums_by_length(int length)
        {
            int nums = 0;
            for (int i = 0; i < string_nums; i++)
            {
                if (text[i].length() == length)
                {
                    nums++;
                }
            }
            return nums;
        }

        /*public void text_output()
        {
            for (int i = 0; i < string_nums; i++)
            {
                for (int j = 0; j < text[i].length(); j++)
                {
                    Console.Write(text[i].str[j]);//к строке и номеру символа к ней(строки)

                }
                Console.WriteLine();

            }
         }
        */
    }
}
