using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.FrontEnd.Infrastructure;
using SimpleBlog.FrontEnd.Models;
using SimpleBlog.FrontEnd.ViewModels;

namespace SimpleBlog.FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IBlogService blogService;

        public HomeController(IBlogService blogService)
        {
            this.blogService = blogService;
        }
        public async Task<IActionResult> Index()
        {
            var posts = await blogService.GetPosts(6);
            HomeViewModel vm = new HomeViewModel();
            vm.FeaturedPosts = posts.Take(3).ToList();
            vm.Boxes = posts.Skip(3).Take(3).ToList();

            return View(vm);       
        }
    }
}
