using System;
using Newtonsoft.Json;
using SimpleBlog.API.Infrastructure;

namespace SimpleBlog.API.Models 
{
    public class Post 
    {
        [JsonIgnore]
        public Guid Guid { 
            get { return System.Guid.NewGuid(); }
            set {} 
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("slug")]
        public string Slug { get
            {
                return StringHelper.Sluggify(Title);
            }
        }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("image")]
        public string Image => "https://via.placeholder.com/150x150";

        [JsonProperty("colour")]
        public int Colour
        {
            get
            {
                //I would presume that in the real world this twould be something fetched from the source
                    return 100000;
            }
        }
    }
}