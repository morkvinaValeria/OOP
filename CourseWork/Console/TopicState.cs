using System;
using System.Collections.Generic;
using System.Text;
using MyLibrary;

namespace ConsoleInterface
{
    class TopicState : MenuState
    {
        private Dictionary<int, MenuItem> _menus = new Dictionary<int, MenuItem>() {
        {1, new MenuItem(){Text = "Add new topic"}},
        {2, new MenuItem(){Text = "Add a tag to existing topic"}},
        {3, new MenuItem(){Text = "Back to Site Menu"}}};
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
                    Console.WriteLine("Enter Topic Name:");
                    string topicName = Console.ReadLine();

                    Console.WriteLine("Enter tags with space");
                    string s = Console.ReadLine();
                    if (s == "")
                    {
                        Console.WriteLine("You must to enter tags!");
                        return new TopicState().RunState(context);
                    }

                    string[] temp = s.Split(' ');
                    List<string> tags = new List<string>();
                    for (int i = 0; i < temp.Length; i++)
                        tags.Add(temp[i]);
                    Topic topic = new Topic(topicName, tags);

                    context.site.AddTopic(topic);
                    topic.TagAdded += Program.TagHandler;
                    Console.WriteLine("Try to add news again.");
                    return new HeadingState1().RunState(context); 
                }
                if (selectedMenu.Key == 2)
                {
                    Console.WriteLine("Enter Topic name to which you want to add a tag:");
                    string topicName = Console.ReadLine();
                    Topic topic = context.site.GetTopicbyName(topicName);
                    Console.WriteLine("Enter a tag");
                    string tag = Console.ReadLine();
                    if (UserRoleType.Anonymous.ToString().Equals(context.user.role))
                    {
                        Console.WriteLine("This type of action is allowed only for registered users");
                        return new SiteMenuState().RunState(context);
                    }
                    topic.AddTag(tag);
                    return new HeadingState1().RunState(context);  
                }
                if (selectedMenu.Key == 3) return null;
                return this;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return new TopicState().RunState(context);
            }
        }
    }
}
