using System;
using System.Collections.Generic;
using MyLibrary;

namespace ConsoleInterface
{
    class Program
    {
        public static void NewsHandler(object owner, string newsName)
        { Console.WriteLine($"Your news «{newsName}» has been added.({owner})");}
        public static void HeadingHandler(object owner, string headingName)
        { Console.WriteLine($"Your heading «{headingName}» has been added.({owner})");}
        public static void TopicHandler(object owner, string topicName)
        {Console.WriteLine($"Your topic «{topicName}» has been added.({owner})");}
        public static void HeadingHandlerDel(object owner, string headingName)
        { Console.WriteLine($"Your heading «{headingName}» has been removed.({owner})"); }
        public static void NewsHandlerDel(object owner, string newsName)
        { Console.WriteLine($"Your news «{newsName}» has been removed.({owner})"); }
        public static void NewsHandlerEmpty(object owner, string headingName)
        { Console.WriteLine($"Heading «{headingName}» has no news now.({owner})"); }
        public static void TagHandler(object owner, string headingName)
        { Console.Write($"Tag «{headingName}» has been added.({owner})"); }

        static void Main(string[] args)
        {
            try
            {
                Heading Food = new Heading("Food"); Heading Music = new Heading("Music");
                Site ololo = new Site("Ololo.com", new List<Heading>(){ Food, Music});
                RegisteredUser milka = new RegisteredUser("milka", "12345", "milka@gmail.com");
                ololo.AddUser(milka);
                milka.role = UserRoleType.Admin.ToString();
                List<string> tagsfood = new List<string>() { "yummy" };
                Topic Cakes = new Topic("Cakes", tagsfood);
                ololo.AddTopic(Cakes);
                Food.AddNews(new News("Tiramisu", "The best dessert", milka, new DateTime(2020, 05, 23), Food, tagsfood));
                Music.AddNews(new News("Rock", "The best music ever", milka, new DateTime(2020, 05, 23), Food));
                Food.NewsAdded += NewsHandler; Music.NewsAdded += NewsHandler;
                Food.NewsRemoved += NewsHandlerDel; Music.NewsRemoved += NewsHandlerDel;
                Food.HeadingIsEmpty += NewsHandlerEmpty; Music.HeadingIsEmpty += NewsHandlerEmpty;
                ololo.HeadingAdded += HeadingHandler; ololo.TopicAdded += TopicHandler;
                ololo.HeadingRemoved += HeadingHandlerDel; Cakes.TagAdded += TagHandler;
                SiteInfoContext context = new SiteInfoContext();
                context.site = ololo;
                IState startState = new InitialState();
                while (startState != null) 
                    startState = startState.RunState(context);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
