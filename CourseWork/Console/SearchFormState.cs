using MyLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleInterface
{
    public class SearchFormState : MenuState
    {
        private Dictionary<int, MenuItem> _menus = new Dictionary<int, MenuItem>() { 
        {1, new MenuItem(){Text = "Search News by Topic"}},
        {2, new MenuItem(){Text = "Search News By Author"}},
        {3, new MenuItem(){Text = "Search News by Period"}},
        {4, new MenuItem(){Text = "Back to Site Menu"}},
        {5, new MenuItem(){Text = "exit"}}};
        protected override Dictionary<int, MenuItem> Menus => _menus;

        protected override IState NextState(KeyValuePair<int, MenuItem> selectedMenu, SiteInfoContext context)
        {
            try
            {
                if (selectedMenu.Key == 1)
                {
                    Console.WriteLine("Enter Topic name:");
                    string topicName = Console.ReadLine();
                    List<News> newsList = context.site.GetNewsByTopic(topicName);
                    Console.WriteLine(context.site.GetNewsListAsString(newsList));
                    return new SearchFormState().RunState(context);
                }
                if (selectedMenu.Key == 2)
                {
                   Console.WriteLine("Enter userName:");
                   string userName = Console.ReadLine();
                   List<News> newsList = context.site.GetNewsByAuthor(userName);
                   Console.WriteLine(context.site.GetNewsListAsString(newsList));
                   return new SearchFormState().RunState(context);
                }
                if (selectedMenu.Key == 3)
                {
                    Console.WriteLine("Enter Start Date in format yyyy-mm-dd:");
                    string startDate = Console.ReadLine();
                    Console.WriteLine("Enter End Date in format yyyy-mm-dd:");
                    string endDate = Console.ReadLine();
                    List<News> newsList = context.site.GetNewsByPeriod(Convert.ToDateTime(startDate), Convert.ToDateTime(endDate));
                    Console.WriteLine(context.site.GetNewsListAsString(newsList));
                    return new SearchFormState().RunState(context);
                }
                if (selectedMenu.Key == 4)
                {
                    return new SiteMenuState().RunState(context);
                }
                if (selectedMenu.Key == 5) return null;
                return this;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return new SearchFormState().RunState(context);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Not suitable format of the date.");
                return new SearchFormState().RunState(context);
            }
        }
    }
}
