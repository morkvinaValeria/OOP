using System;
using System.Collections.Generic;
using System.Text;

namespace lab5._2_cSharp
{
    class LowerCaseString : MyString
    {
        private string str;

        public LowerCaseString(string str)
        {
            this.str = str.ToLower();

            for (int i = 0; i < GetLength(); i++)
            {
                if ((!(this.str[i] >= 'a') || !(this.str[i] <= 'z')))
                {
                    this.str = this.str.Remove(i, 1);
                    i--;
                }
            }
        }

        override public int GetLength() => str.Length;

        override public string Shift()
        {
           char [] temp = str.ToCharArray();
            char x = temp[0]; 
            for(int i=0; i<GetLength()-1;i++)
            {
                temp[i] = temp[i + 1];
            }
            temp[GetLength()-1] = x;
            str = new string(temp);
            return str;
        }

    }
}
