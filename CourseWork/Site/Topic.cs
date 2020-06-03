using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Topic
    {
        private string topicName;
        private List<string> tags;

        public delegate void Del(object sender, string Name);
        public event Del TagAdded = null;
        public event Del TagRemoved = null;

        public Topic(string topicName, List<string> tags)
        {
            if (topicName == null || tags == null || tags.Count == 0)
                throw new ArgumentException(message: "Topic name and tags cannot be null");

            this.topicName = topicName;
            this.tags = tags;
        }
        public string GetTopicName() => topicName;
        public List<string> GetTags() => tags;
        public void AddTag(string tag)
        {
            if (tag == null)
                throw new ArgumentException(message: "Tag cannot be null");

            tags.Add(tag);
            TagAdded?.Invoke(this, tag);
        }
        public void RemoveTag(string tag)
        {

            if (tags == null || tags.Count == 0)
            {
                throw new ArgumentException(message: "TagsList cannot be null");
            }
            tags.Remove(tag);
            TagRemoved?.Invoke(this, tag);
        }
        public bool IsTagContained(List<string> tagsIn)
        {
            if (tagsIn == null) return false;
            foreach (string tag in tagsIn)
            {
                if (tags.Contains(tag))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
