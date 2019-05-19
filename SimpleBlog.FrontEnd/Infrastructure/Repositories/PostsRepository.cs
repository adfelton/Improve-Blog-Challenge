using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SimpleBlog.FrontEnd.Infrastructure 
{
    public class PostsRepository : IPostsRepository 
    {
        public static IWebClient _client;

        public PostsRepository(IWebClient client)
        {
            _client = client;
        }

        public async Task<Post> Get<Post>(int id)
        {
            var json = await _client.GetData($"/{id}");
            return JsonConvert.DeserializeObject<Post>(json);
        }
        public async Task<Post> Get<Post>(String slug)
        {
            var json = await _client.GetData($"/{slug}");
            return JsonConvert.DeserializeObject<Post>(json);
        }

        public async Task<IList<Post>> GetN<Post>(int count)
        {
       
            var posts = await GetAll<Post>();
            return posts.Take(count).ToList();
        }

        public async Task<IList<Post>> GetAll<Post>()
        {
            var json = await _client.GetData();
            return JsonConvert.DeserializeObject<List<Post>>(json);
        }
    }
}