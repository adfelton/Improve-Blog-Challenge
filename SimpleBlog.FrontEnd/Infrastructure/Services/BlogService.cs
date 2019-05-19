using SimpleBlog.FrontEnd.Models;
using SimpleBlog.FrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog.FrontEnd.Infrastructure
{
   
    public class BlogService : IBlogService
    {
        protected readonly IPostsRepository postsRepo;
        protected readonly ICommentsRepository commentsRepo;

        public BlogService(IPostsRepository postsRepo, ICommentsRepository commentsRepo)
        {
            this.postsRepo = postsRepo;
            this.commentsRepo = commentsRepo;
        }


        public async Task<IList<Post>> GetPosts(int number = 0)
        {
            if (number == 0)
            {
                var posts = await postsRepo.GetAll<Post>();
                return posts;
            }
            else
            {
                var posts = await postsRepo.GetN<Post>(number);
                return posts;
            }
        }

        public async Task<IList<Post>> GetPostsWithComments()
        {
            var posts = await postsRepo.GetAll<Post>();
            foreach (var post in posts)
            {
                var comments = await commentsRepo.GetAll<Comment>(post.Id);
                post.Comments = comments.ToList();
            }
            return posts;
        }

        public async Task<Post> GetPostWithComments(int id)
        {
            var post = await postsRepo.Get<Post>(id);
            var comments = await commentsRepo.GetAll<Comment>(post.Id);
            post.Comments = comments.ToList();
            
            return post;
        }
    }
}
