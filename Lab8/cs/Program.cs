using System;
using Library;
using System.Diagnostics;
using System.Threading;

namespace lab8
{
    class Program
    {
        public static void Handler(object owner, float m)
        {
            Console.WriteLine($"{owner} Your balance: {m}. Replenish your balance");
        }

        static void Main(string[] args)
        {
            try
            {
                Diagonal d = new Diagonal(new string[,] { { "apple", "apricot" }, { "orange", "cherry" } });
                d.Get_MainDiagonal();
                Diagonal.MainDiagonal del = Diagonal.Get_MainDiagonal;
                del?.Invoke(new string[,] { { "apple", "apricot" }, { "orange", "cherry" } });

                MobileСonnection mc = new MobileСonnection("Standart");
                mc.MinBalance += Handler;
                mc.AccountBalance = 100;
                mc.ActivationPlan();
                mc.TimeTalk(10);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
