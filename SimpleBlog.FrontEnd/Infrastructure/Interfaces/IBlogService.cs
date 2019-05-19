using SimpleBlog.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog.FrontEnd.Infrastructure
{
    public interface IBlogService
    {

        Task<IList<Post>> GetPosts(int number = 0);

        Task<IList<Post>> GetPostsWithComments();

        Task<Post> GetPostWithComments(int id);
    }
}
