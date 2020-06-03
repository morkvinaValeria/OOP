using System;
using System.Collections.Generic;
using System.Text;
using MyLibrary;

namespace ConsoleInterface
{
    public static class Registration
    {
        public static bool Register(Site site)
        {
            Console.WriteLine("*****REGISTRATION*****");
            Console.Write("Enter Username: ");
            string userName = Console.ReadLine();
            if (userName == "")
                throw new ArgumentException(message: "userName cannot be null");
            Console.Write("Enter password: ");
            bool incorrectPass = true;
            string pass = Console.ReadLine();
            if (pass == "")
                throw new ArgumentException(message: "userName cannot be null");
            while (incorrectPass)
            {
                Console.Write("Re-enter password: ");
                string reenterPass = Console.ReadLine();

                if (pass.Equals(reenterPass))
                    incorrectPass = false;
            }
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            try
            {
                site.AddUser(new RegisteredUser(userName, pass, email));
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("If you want to exit - enter 0 or enter any other number to try again to Register.");
                int a;
                string b = Console.ReadLine();
                while (!int.TryParse(b, out a))
                {
                    Console.WriteLine("It`s not a number. Try again.");
                    b = Console.ReadLine();
                }
                if (Convert.ToInt32(b) == 0)
                    throw new ArgumentException(message: "You are exit.");

                return Register(site);
            }
            return true;
        }

    }
}