using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.FrontEnd.Infrastructure;
using SimpleBlog.FrontEnd.Models;
using SimpleBlog.FrontEnd.ViewModels;

namespace SimpleBlog.FrontEnd.Controllers
{
    public class PostsController : Controller
    {
        protected readonly IBlogService blogService;

        public PostsController(IBlogService blogService) 
        {
            this.blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            //The "GetPostsWithComments" has some serious speed implications. This could be offset by implementing server side pagination.
            var posts = await blogService.GetPostsWithComments();
            var vm = new PostsViewModel
            {
                Posts = posts.ToList()
            };
            return View(vm);
        }

        public async Task<IActionResult> Details(int id, string slug)
        {
            var post = await blogService.GetPostWithComments(id);
            return View(post);
        }

        #region Extra Bits
        //Leaving this is evidence that it's possible to literally replace the id in all circumstances, though this is definitely not optimal. 
        //Uncommenting would require some rewriting as this was written before introduction of blogService
        //public async Task<IActionResult> Details(string id)
        //{
        //    //Get posts from tempdata if possible
        //    List<Post> posts = (List<Post>)TempData["Posts"];
        //    if (posts == null)
        //    {
        //        var _posts = await postsRepo.GetAll<Post>();
        //        posts = _posts.ToList();
        //        TempData.Add("Posts", posts);
        //    }

        //    var post = posts.FirstOrDefault(x => x.Slug == id);
        //    var comments = await commentsRepo.GetAll<Comment>(post.Id);
        //    var vm = new PostDetailsViewModel
        //    {
        //        Post = post,
        //        Comments = comments.ToList(),
        //    };
        //    return View(vm);
        //}
        #endregion
    }
}
