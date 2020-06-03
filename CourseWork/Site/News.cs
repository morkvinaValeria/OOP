using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class News
    {
        public string newsName { get; }
        public Heading header { get; }
        public string newsContent { get; }
        public User author { get; }
        public List<string> tags { get; }
        public DateTime createdDate { get; }

        public News(string newsName, string newsContent, User author, DateTime createdDate, Heading header, List<string> tags)
        {
            this.newsName = newsName;
            this.newsContent = newsContent;
            this.author = author;
            this.createdDate = createdDate;
            this.header = header;
            this.tags = tags;
        }
        public News(string newsName, string newsContent, User author, DateTime createdDate, Heading header)
        {
            this.newsName = newsName;
            this.newsContent = newsContent;
            this.author = author;
            this.createdDate = createdDate;
            this.header = header;
        }

        public override string ToString()
        {
            return "News name: "+newsName+"\nNews Content:"+newsContent+"\nAuthor: "+author.userName;
        }
    }
}






















/* public override bool Equals(Object o)
       {
           if (this == o)
               return true;
           if (!(o is News))
               return false;
           News news = (News)o;
           return Object.Equals(newsName, news.newsName);
       }*/
