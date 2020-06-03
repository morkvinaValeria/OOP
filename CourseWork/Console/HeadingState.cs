using MyLibrary;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Schema;

namespace ConsoleInterface
{
    public class HeadingState : MenuState
    {
        private Dictionary<int, MenuItem> _menus = new Dictionary<int, MenuItem>();
        protected override Dictionary<int, MenuItem> Menus => _menus;

        public override IState RunState(SiteInfoContext context)  
        {
            List<Heading> headerList = context.site.GetHeaderList();
            Console.WriteLine("Select Header");
            for(int i =0; i < headerList.Count; i++)  
            {
                AddMenuItem(i, new MenuItem() { Text = headerList[i].GetHeaderName() }); 
            }
            var option = ReadOption(); 
            return NextState(option, context);  
        }

        protected override IState NextState(KeyValuePair<int, MenuItem> selectedMenu, SiteInfoContext context)
        {
            context.heading = context.site.GetHeaderList()[selectedMenu.Key];
            List<News> newsList = context.site.GetNewsByHeader(context.heading.GetHeaderName());
            Console.WriteLine(context.site.GetNewsListAsString(newsList));
            return new HeadingState1().RunState(context);
        }

        public void AddMenuItem(int id, MenuItem menu) 
        {
            _menus.Add(id, menu);
        }
    }
}
