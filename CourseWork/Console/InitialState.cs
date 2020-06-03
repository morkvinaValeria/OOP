using MyLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleInterface
{
    public class InitialState : MenuState  
    {
        private Dictionary<int, MenuItem> _menus = new Dictionary<int, MenuItem>() {
        {1, new MenuItem(){Text = "Login"}},
        {2, new MenuItem(){Text = "Login Anonymously"}},
        {3, new MenuItem(){Text = "Register"}},
        {4, new MenuItem(){Text = "Exit"}}};
        protected override Dictionary<int, MenuItem> Menus => _menus;

        protected override IState NextState(KeyValuePair<int, MenuItem> selectedMenu, SiteInfoContext context)
        {

            if (selectedMenu.Key == 1) {
               
                context.user = Login.LoginCustomer(true, context.site);

                return new SiteMenuState().RunState(context); 
            }
            if (selectedMenu.Key == 2) {
                context.user = Login.LoginCustomer(false, context.site); 
                return new SiteMenuState().RunState(context); 
            }
            if (selectedMenu.Key == 3) {
                Registration.Register(context.site); 
                context.user = Login.LoginCustomer(true, context.site); 
                return new SiteMenuState().RunState(context); 
            }
            if (selectedMenu.Key == 4) return null;
            return this;
        }
    }
}
