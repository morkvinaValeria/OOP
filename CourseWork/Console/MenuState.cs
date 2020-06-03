using MyLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleInterface
{
    public abstract class MenuState : IState 
    {
        protected abstract Dictionary<int, MenuItem> Menus { get; }

        protected virtual void ShowMenu()
        {
            Console.WriteLine(" Options:");
            foreach (var m in Menus)
            {
                Console.Write($"{m.Key} - {m.Value.Text}\t\t");
                if (m.Key % 2 == 0) Console.WriteLine("");
                
            }
        }

        protected virtual KeyValuePair<int, MenuItem> ReadOption() 
        {
            Console.Write(" Please, select option.");
            ShowMenu();

            var str = Console.ReadLine();  
            int answerId = 0;

            if (int.TryParse(str, out answerId)) 
            {
                if (!Menus.ContainsKey(answerId))  
                {
                    Console.WriteLine("Selected item not exists.");
                    return ReadOption();  
                }
                return new KeyValuePair<int, MenuItem>(answerId, Menus[answerId]);  
            }
            else
            {
                Console.WriteLine(" Selected item not a number."); 
                return ReadOption();  
            }
        }

        public virtual IState RunState(SiteInfoContext context) 
        {
            var option = ReadOption();  //считываем опцию
            return NextState(option, context);  //переходим к слующему меню-состоянию
        }

        protected abstract IState NextState(KeyValuePair<int, MenuItem> selectedMenu, SiteInfoContext context);
    }
}
