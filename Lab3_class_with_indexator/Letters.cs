using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Letters
    {

        private char[,] array = new char[5, 5];
        public void set(char[,] array)
        {

            this.array = array;
        }
        public char[,] get()
        {
            return this.array;
        }

        public string this[int index]
        {
            get
            {
                char[] arr = new char[array.GetLength(1)]; 
                for (int i = 0; i < array.GetLength(0); i++)
                    arr[i] = array[index, i];
                return new string(arr);
            }
        }

        public int ConsonantsCount
        {

            get
            {
                string consonants = "bcdfghjklmnpqrstvwxz";
                int count = 0;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if (consonants.Contains(array[i, j])) count++;
                    }
                }

                return count;
            }
        }


        public void text_output()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();

            }
        }

    }
}
