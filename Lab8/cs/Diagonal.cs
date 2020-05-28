using System;
using System.Collections.Generic;
using System.Text;

namespace lab8
{
    class Diagonal
    {
        private string[,] a;
        public Diagonal(string[,] a)
        {
            if (a.GetLength(0) == 0 && a.GetLength(1) == 0)
                throw new ArgumentException(message: "Array cannot be null");

            this.a = a;
        }

        public delegate string[] MainDiagonal(string[,] a);

        public string[] Get_MainDiagonal()
        {
            int n;
            if (a.GetLength(0) >= a.GetLength(1))
                n = a.GetLength(0);
            else
                n = a.GetLength(1);
            
            string[] b = new string[n];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (i == j)
                        b[i] = a[i, j];
            return b;
        }

        static public string[] Get_MainDiagonal(string[,] a)
        {
            if (a.GetLength(0) == 0 && a.GetLength(1) == 0)
                throw new ArgumentException(message: "Array cannot be null");

            int n;
            if (a.GetLength(0) >= a.GetLength(1))
                n = a.GetLength(0);
            else
                n = a.GetLength(1);

            string[] b = new string[n];
            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    if (i == j)
                        b[i] = a[i, j];
            return b;
        }
    }
}
