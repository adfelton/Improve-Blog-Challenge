using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleBlog.FrontEnd.Models 
{
    public class Post 
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("colour")]
        public int Colour { get; set; }
        public int CommentCount { get
            {
                if (Comments != null)
                    return Comments.Count;
                else
                    return 0;
            }
        }

        public IList<Comment> Comments { get; set; }
    }
}