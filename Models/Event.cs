using System;

namespace GitHubUserActivity.Models
{
    internal class Event
    {
        public string id { get; set; }
        public string type { get; set; }
        public Repo repo { get; set; }
        public Payload payload { get; set; }
        public DateTime created_at { get; set; }
    }
}
