using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class MyString
    {
        private char[] str;


        public MyString(char[] str)
        {
            int length = 0;
            int i = 0;
            while (str[i] != '\n')
            {
                length++;
                i++;
            }
            this.str = new char[length + 1];
            for (int j = 0; j < length + 1; j++)
            {
                this.str[j] = str[j];
            }
        }
        public int length()
        {
            int length = 0;
            int i = 0;
            if (str == null) { return length; }
            while (str[i] != '\n')
            {
                length++;
                i++;
            }
            return length;
        }

        public int getwordsamount()
        {
            int amount = 0;
            for (int i = 0; i < length(); i++)
            {
                if (str[i] == ' ')
                {
                    amount++;
                }
            }
            return amount + 1;
        }
        public int getCapitalWordId(int index)
        {
            int id = 0;
            int current_index = 1;

            for (int i = 0; i < length(); i++)
            {
                if (str[i] == ' ')
                {
                    if (current_index == index)
                    {
                        return id;
                    }
                    id = i + 1;
                    current_index++;
                    i++;
                }

            }
            return id;
        }
        public void toUpperCase()
        {
            for (int i = 0; i < this.getwordsamount(); i++)
            {
                if ((this.str[getCapitalWordId(i + 1)] >= 'a') && (this.str[getCapitalWordId(i + 1)] <= 'z'))
                    this.str[getCapitalWordId(i + 1)] = (char)(this.str[getCapitalWordId(i + 1)] - 32);
            }
        }

        public char[] getkey()
        {
            char[] key = new char[getwordsamount() + 1];
            for (int i = 1; i <= getwordsamount(); i++)
            {
                key[i - 1] = str[getCapitalWordId(i)];
            }
            key[getwordsamount()] = '\n';
            return key;
        }

        public bool equal(MyString mystring)
        {
            int equals = 0;
            if (this.str == mystring.str) return true;
            if (length() == mystring.length())
            {
                for (int i = 0; i < length(); i++)
                {
                    if (str[i] == mystring.str[i])
                    {
                        equals++;
                    }
                }
                if (equals == length())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool isEmpty()
        {
            return length() == 0;
        }
    }
}
