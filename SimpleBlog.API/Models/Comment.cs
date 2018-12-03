using System;
using Newtonsoft.Json;

namespace SimpleBlog.API.Models 
{
    public class Comment 
    {
        [JsonIgnore]
        public Guid Guid { 
            get { return System.Guid.NewGuid(); }
            set {} 
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("postId")]
        public int PostId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("avatar")]
        public string Avatar => "https://via.placeholder.com/50x50";
    }
}