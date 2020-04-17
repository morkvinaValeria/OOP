using System;
using System.Collections.Generic;
using System.Text;

namespace lab5._2_cSharp
{
    class DigitalString : MyString
    {
        private string str;
        public DigitalString(string str)
        {
            this.str = str;

            for (int i= 0; i < GetLength();i++)
            {
                if (!(this.str[i]>='0') || !(this.str[i]<='9'))
                {
                   this.str = this.str.Remove(i, 1);
                    i--;
                }
            }
        }

        override public int GetLength() => str.Length;

        public override string Shift()
        {
            char[] temp = str.ToCharArray();
            char x = temp[GetLength() - 1];
            for (int i = GetLength() - 1; i >0; i--)
            {
                temp[i] = temp[i-1];
            }
            temp[0] = x;
            str = new string(temp);
            return str;
        }

    }
}
