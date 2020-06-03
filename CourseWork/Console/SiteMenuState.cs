using MyLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleInterface
{
    public class SiteMenuState : MenuState  
    {
        private Dictionary<int, MenuItem> _menus = new Dictionary<int, MenuItem>() {
        {1, new MenuItem(){Text = "Find news"}},
        {2, new MenuItem(){Text = "Open Heading"}},
        {3, new MenuItem(){Text = "Add Heading"}},
        {4, new MenuItem(){Text = "Remove Heading"}},
        {5, new MenuItem(){Text = "Logout"}},
        {6, new MenuItem(){Text = "Exit"}}};
        protected override Dictionary<int, MenuItem> Menus => _menus;

        protected override IState NextState(KeyValuePair<int, MenuItem> selectedMenu, SiteInfoContext context)
        {
            try
            {
                if (selectedMenu.Key == 1) return new SearchFormState().RunState(context);
                if (selectedMenu.Key == 2) return new HeadingState().RunState(context);
                if (selectedMenu.Key == 3)
                {
                   if (!UserRoleType.Admin.ToString().Equals(context.user.role))
                   {
                      Console.WriteLine("This type of action is allowed only for admin");
                      return new SiteMenuState().RunState(context);
                   }
                    Console.WriteLine("Enter Heading name:");
                    string headerName = Console.ReadLine();
                    Heading HeaderName = new Heading(headerName);
                    HeaderName.NewsAdded += Program.NewsHandler;
                    HeaderName.NewsRemoved += Program.NewsHandlerDel;
                    HeaderName.HeadingIsEmpty += Program.NewsHandlerEmpty;
                    context.site.AddHeader(HeaderName);
                    return new SiteMenuState().RunState(context);
                }
                if (selectedMenu.Key == 4)
                {
                   if (!UserRoleType.Admin.ToString().Equals(context.user.role))
                   {
                     Console.WriteLine("This type of action is allowed only for admin");
                      return new SiteMenuState().RunState(context);
                   }
                   Console.WriteLine("Enter Heading name that you want to remove:");
                   string headingName = Console.ReadLine();
                   Heading heading = context.site.GetHeadingbyName(headingName);
                   context.site.RemoveHeader(heading);
                }
                if (selectedMenu.Key == 5)
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
                if (selectedMenu.Key == 6) return null;

                return this;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return new SiteMenuState().RunState(context);
            }
        }
    }
}
