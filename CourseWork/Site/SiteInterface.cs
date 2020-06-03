using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public interface SiteInterface
    {
        void AddHeader(Heading header);
        void AddTopic(Topic topic);
        void AddUser(User user);
        List<News> GetNewsByHeader(string headerName);
        List<News> GetNewsByAuthor(string userName);
        List<News> GetNewsByTopic(string topicName);
        List<News> GetNewsByPeriod(DateTime start, DateTime end);
        string GetUsersInfo();

    }
}
