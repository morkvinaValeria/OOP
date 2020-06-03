using System;
using System.Collections.Generic;
using System.Text;
using MyLibrary;

namespace ConsoleInterface
{
    public static class Login
    {
        public static User LoginCustomer(bool registered, Site site)
        {
            if (registered) 
               return Run(site);
            else
               return LoginAnonymously(site);
        }

        private static User Run(Site site)
        {
            Console.WriteLine("\n*****LOGIN*****");
            Console.Write("Enter Username:");
            string userName = Console.ReadLine();
            
            Console.Write("Enter password: ");
            string pass = Console.ReadLine();
            Dictionary<User, bool> userMap = ExecuteAuthorization(userName, pass, site);
            if (userMap.ContainsValue(true))
            {
                Console.WriteLine("Authorization is successful");
                IEnumerator<User> dictionary = userMap.Keys.GetEnumerator();
                dictionary.MoveNext();
                return dictionary.Current;
            }
            else
            {
                Console.WriteLine("Authorization is Failed. Try again");
                Console.WriteLine("If you want to exit - enter 0 or enter any other number to try again to Login.");
                int a;
                string b = Console.ReadLine();
                while (!int.TryParse(b, out a))
                {
                    Console.WriteLine("It`s not a number. Try again.");
                    b = Console.ReadLine();
                }
                if (Convert.ToInt32(b) == 0)
                    throw new ArgumentException(message: "You are exit.");
                return Run(site);

            }
        }
        private static Dictionary<User,bool> ExecuteAuthorization(string userName, string pass, Site site)
        {
            Dictionary<User, bool> mapUserToBool = new Dictionary<User, bool>();
            List<User> userList = site.GetUserList();
            for (int i=0; i < userList.Count; i++)
            {
                if (userList[i].GetType().Name.Equals("AnonymousUser"))
                    continue;
                if (userName.Equals(userList[i].userName))
                {
                    if (pass.Equals(((RegisteredUser)userList[i]).password))
                    {
                        userList[i].active = true;
                        mapUserToBool.Add(site.GetUserbyName(userName), true);
                        return mapUserToBool;
                    }
                    else
                    {
                        Console.WriteLine("Password is incorrect");
                        break;
                    }
                }
            }
            return mapUserToBool;
        }

        private static User LoginAnonymously(Site site)
        {
            List<AnonymousUser> anonymousList = site.anonymousList;
            if (anonymousList == null)
            {
                anonymousList = new List<AnonymousUser>();
            }
            AnonymousUser anoymous = new AnonymousUser();
            anonymousList.Add(anoymous);
            site.AddUser(anoymous);
            anoymous.active=true;
            return anoymous;
        }
        public static void LogOutAnonymous(User user, Site site)
        {
            site.anonymousList.Remove((AnonymousUser)user);
            site.GetUserList().Remove(user);
        }

       public static void LogOut(User user)
       {
            user.active=false;
       }
    }
}
