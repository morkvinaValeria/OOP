using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Site : SiteInterface
    {
        private string webAddress;
        private List<Heading> headingList;
        private List<User> userList;
        private List<Topic> topicList;

        public delegate void Del(object sender, string Name);
        public event Del HeadingAdded = null;
        public event Del TopicAdded = null;
        public event Del HeadingRemoved = null;
        public event Del TopicRemoved = null;

        public List<AnonymousUser> anonymousList { get; }

        public Site(string webAddress, List<Heading> headingList)
        {
            if( webAddress == null || headingList.Count < 0 || headingList == null )
            {
                throw new ArgumentException(message: "webAddress and headerList cannot be null");
            }
            this.webAddress = webAddress;
            this.headingList = headingList;
        }
        public Site(string webAddress)
        { if (webAddress == null )
            {
                throw new ArgumentException(message: "webAddress and headerList cannot be null");
            }
            this.webAddress = webAddress;
        }
        public List<Heading> GetHeaderList()
        {
            return headingList;
        }
        public List<Topic> GetTopicList()
        {
            return topicList;
        }
       
        public void AddUser(User user)
        {
            if(IsUserContained(user.userName))
                throw new ArgumentException(message: "User already exists");

            if (userList == null)
                userList = new List<User>();

            userList.Add(user);
        }

        public void AddTopic(Topic topic)
        {
            if (IsTopicContained(topic.GetTopicName()))
                throw new ArgumentException(message: "Topic already exists");

            if (topicList == null)
            {
                topicList = new List<Topic>();
            }
            topicList.Add(topic);
            TopicAdded?.Invoke(this, topic.GetTopicName());
        }
        public void RemoveTopic(Topic topic)
        {
            if (topicList == null || topicList.Count == 0)
            {
                throw new ArgumentException(message: "TopicList cannot be null");
            }
            topicList.Remove(topic);
            TopicRemoved?.Invoke(this, topic.GetTopicName());
        }
        public void AddHeader(Heading header)
        {
            if (IsHeadingContained(header.GetHeaderName()))
                throw new ArgumentException(message: $"This header <{header.GetHeaderName()}> is already exists. Try again.");

            if (headingList == null)
                headingList = new List<Heading>();

            headingList.Add(header);
            HeadingAdded?.Invoke(this, header.GetHeaderName());
        }
        public void RemoveHeader(Heading heading)
        {
            if (headingList == null || headingList.Count == 0)
                throw new ArgumentException(message: "HeaderList cannot be null");

            if (headingList.Count == 1)
                throw new ArgumentException(message: "You cannot remove the last header.");

            headingList.Remove(heading);
            HeadingRemoved?.Invoke(this, heading.GetHeaderName());
        }
        public List<News> GetNewsByHeader(string headerName)
        {
            if (headerName == null)
                throw new ArgumentException(message: "Name of header cannot be null");

            if (IsHeadingContained(headerName) == false)
                throw new ArgumentException(message: "There is not such heading");

            for (int i=0; i< headingList.Count; i++)
            {
               if(headerName.Equals(headingList[i].GetHeaderName()))
               { 
                  return headingList[i].GetNewsList();
               }
            }
            throw new ArgumentException(message: $"There is no news in Header -{headerName}");
        }

        public List<News> GetNewsByAuthor(string userName)
        {
            if (userName == null)
                throw new ArgumentException(message: "Name of author cannot be null");

            if(IsUserContained(userName) == false)
                throw new ArgumentException(message: "There is not such author");

            List<News> newsListByAuthor = new List<News>();
            for (int i = 0; i < headingList.Count; i++)
                newsListByAuthor.AddRange(headingList[i].GetNewsByAuthor(userName));

            if(newsListByAuthor.Count == 0)
                throw new ArgumentException(message: $"There is no news by this user -{userName}");
            return newsListByAuthor;
        }

        public List<News> GetNewsByPeriod(DateTime start, DateTime end)
        {
            if (start == null || end == null)
                throw new ArgumentException(message: "The start Date cannot be null");

            List<News> newsListByPeriod = new List<News>();
            for (int i = 0; i < headingList.Count; i++)
            {
                newsListByPeriod.AddRange(headingList[i].GetNewsByPeriod(start, end));
            }
            if (newsListByPeriod.Count == 0)
                throw new ArgumentException(message: $"There is no news by this period");
            return newsListByPeriod;
        }

        public List<News> GetNewsByTopic(string topicName)
        {
            if (topicName == null)
                throw new ArgumentException(message: "Name of the topic cannot be null");
         
            List<News> newsListByTopic = new List<News>();
            Topic topic = GetTopicbyName(topicName);
            for(int i =0; i< headingList.Count; i++)
            {
                newsListByTopic.AddRange(headingList[i].GetNewsByTopic(topic));
            }
            if(newsListByTopic.Count == 0)
                throw new ArgumentException(message: $"There is no news by this topic -{topicName}");
            return newsListByTopic;
        }
        public bool IsTagContained(string tagIn)
        {
            if (tagIn == null) return false;
            foreach (Topic topic in topicList)
                if (topic.GetTags().Contains(tagIn))
                    return true;
            return false;
        }
        private bool IsUserContained(string userName)
        {
            if (userList == null) return false;
            bool isContain = false;
            foreach (User users in userList)
                if (users.userName == userName)
                    isContain = true;
            return isContain;
        }
        private bool IsTopicContained(string topicName)
        {
            if (topicList == null) return false;
            bool isContain = false;
            foreach (Topic topics in topicList)
                    if (topics.GetTopicName() == topicName)
                    isContain = true;
            return isContain;
        }
        private bool IsHeadingContained(string headingName)
        {
            if (headingList == null) return false;
            bool isContain = false;
            foreach (Heading headings in headingList)
                if (headings.GetHeaderName() == headingName)
                    isContain = true;
            return isContain;
        }
        public string GetNewsListAsString(List<News> newsList)
        {
            StringBuilder newsString = new StringBuilder();
            foreach (News news in newsList)
            {
                newsString.Append(news.ToString());
                newsString.Append("\n");
            }
            return newsString.ToString();
        }
        public User GetUserbyName(string userName)
        {
            for (int i = 0; i < userList.Count; i++)
            {
                if (userName.Equals(userList[i].userName))
                    return userList[i];
            }
            throw new ArgumentException("User is not found.");
        }
        public Heading GetHeadingbyName(string headingName)
        {
            for (int i = 0; i < headingList.Count; i++)
            {
                if (headingName.Equals(headingList[i].GetHeaderName()))
                    return headingList[i];
            }
            throw new ArgumentException(message: "Heading is not found");
        }
        public Topic GetTopicbyName(string topicName)
        {
            for (int i = 0; i < topicList.Count; i++)
            {
                if (topicName.Equals(topicList[i].GetTopicName()))
                {
                    return topicList[i];
                }
            }
            throw new ArgumentException(message: "Topic is not found");
        }
        public string GetUsersInfo() => userList.ToString();
        public List<User> GetUserList() => userList;
    }
}

