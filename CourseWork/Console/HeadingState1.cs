using MyLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleInterface
{
    public class HeadingState1 : MenuState
    {
        private Dictionary<int, MenuItem> _menus = new Dictionary<int, MenuItem>() {  
        {1, new MenuItem(){Text = "Add News"}},
        {2, new MenuItem(){Text = "Remove News"}},
        {3, new MenuItem(){Text = "Logout"}},
        {4, new MenuItem(){Text = "Back to Site Menu"}}}; 
        protected override Dictionary<int, MenuItem> Menus => _menus;

        protected override IState NextState(KeyValuePair<int, MenuItem> selectedMenu, SiteInfoContext context)
        {
            try
            {
                if (selectedMenu.Key == 1)
                {
                    if (UserRoleType.Anonymous.ToString().Equals(context.user.role))
                    {
                        Console.WriteLine("This type of action is allowed only for registered users");
                        return new SiteMenuState().RunState(context);
                    }
                    Console.WriteLine("Enter News Name:");
                    string newsName = Console.ReadLine();
                    Console.WriteLine("Enter news content");
                    string newsContent = Console.ReadLine();
                    Console.WriteLine("Enter tags with space or press enter");
                    string s = Console.ReadLine();
                    if (s != "")
                    {
                        string[] temp = s.Split(' ');
                        List<string> tags = new List<string>();
                        for (int i = 0; i < temp.Length; i++)
                            tags.Add(temp[i]);
                        foreach (var tag in tags)
                            if (!context.site.IsTagContained(tag))
                            {
                                Console.WriteLine($"{tag} is not found.");
                                return new TopicState().RunState(context);
                            }
                        News news = new MyLibrary.News(newsName, newsContent, context.user, DateTime.Now, context.heading, tags);
                        context.heading.AddNews(news);
                    }
                    else
                    {
                        News news = new MyLibrary.News(newsName, newsContent, context.user, DateTime.Now, context.heading);
                        if (UserRoleType.Anonymous.ToString().Equals(news.author.role))
                        {
                            Console.WriteLine("This type of action is allowed only for registered users");
                            return new SiteMenuState().RunState(context);
                        }
                        context.heading.AddNews(news);
                    }
                    return new HeadingState1().RunState(context);
                }
                if (selectedMenu.Key == 2)
                {
                    if (!UserRoleType.Admin.ToString().Equals(context.user.role))
                    {
                        Console.WriteLine("This type of action is allowed only for admin");
                        return new SiteMenuState().RunState(context);
                    }
                    Console.WriteLine("Enter News name that you want to remove:");
                    string newsName = Console.ReadLine();
                    News news = context.heading.GetNewsbyName(newsName);
                    context.heading.RemoveNews(news);
                    return new SiteMenuState().RunState(context);

                }
                if (selectedMenu.Key == 3)
                {
                    if (UserRoleType.Anonymous.Equals(context.user.role))
                    {
                        Login.LogOutAnonymous(context.user, context.site);
                        context.user = null;
                        context.heading = null;
                        return new InitialState().RunState(context);
                    }
                    Login.LogOut(context.user);
                    context.user = null;
                    context.heading = null;
                    return new InitialState().RunState(context);
                }
                if (selectedMenu.Key == 4) return new SiteMenuState().RunState(context);
                return this;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return new HeadingState1().RunState(context);
            }
        }
       
    }
}
