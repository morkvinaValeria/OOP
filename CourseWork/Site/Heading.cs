using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{    public class Heading
    { 
        public delegate void Del(object sender, string Name);
        public event Del NewsAdded = null;
        public event Del NewsRemoved = null;
        public event Del HeadingIsEmpty = null;

        private string headingName;
        private List<News> newsList;

        public Heading(string headingName)
        {
            if (headingName == null)
                throw new ArgumentException(message: "Name of header cannot be null");

            this.headingName = headingName;
        }

        public string GetHeaderName()
        {
            return headingName;
        }
        public List<News> GetNewsList()
        {
            return newsList;
        }
        public void AddNews(News news)
        {
            if (UserRoleType.Anonymous.ToString().Equals(news.author.role))
                throw new ArgumentException(message: "This type of action is allowed only for registered users");

            if (newsList == null)
            {
                 newsList = new List<News>();
            }
            newsList.Add(news);
            NewsAdded?.Invoke(this, news.newsName);
        }

        public void RemoveNews(News news)
        {
            if (newsList == null || newsList.Count == 0)
            {
                throw new ArgumentException(message: "List of news cannot be null");
            }
            newsList.Remove(news);
            NewsRemoved?.Invoke(this, news.newsName);

            if (newsList.Count == 0)
                HeadingIsEmpty?.Invoke(this, headingName);
        }

        public List<News> GetNewsByAuthor(string userName)
        {
            if (userName == null)
                throw new ArgumentException(message: "Name of the user cannot be null");

            List<News> filteredAuthor = new List<News>();
            for (int i = 0; i < newsList.Count; i++)
                if (userName.Equals(newsList[i].author.userName))
                    filteredAuthor.Add(newsList[i]);

            return filteredAuthor;
        }

        public List<News> GetNewsByPeriod(DateTime start, DateTime end)
        {
            if (start == null || end == null)
            {
                throw new ArgumentException(message: "Period of time cannot be null");
            }
            List<News> filteredNews = new List<News>();
            for (int i = 0; i < newsList.Count; i++)
            {
                if (newsList[i].createdDate> start && newsList[i].createdDate < end)
                {
                    filteredNews.Add(newsList[i]);
                }
            }
            return filteredNews;
        }

        public List<News> GetNewsByTopic(Topic topic)
        {
            List<News> filteredListByTopic = new List<News>();
            foreach(News news in newsList)
            {
                if (topic.IsTagContained(news.tags))
                {
                    filteredListByTopic.Add(news);
                    continue;
                }
            }
            return filteredListByTopic;
        }

        public News GetNewsbyName(string newsName)
        {
            for (int i = 0; i < newsList.Count; i++)
            {
                if (newsName.Equals(newsList[i].newsName))
                    return newsList[i];
            }
            throw new ArgumentException(message: $"{ newsName } - there is no such news.Try again.");
        }
    }
}