using SimpleBlog.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog.FrontEnd.ViewModels
{
    public class HomeViewModel
    {
        public List<Post> FeaturedPosts { get; set; }
        public List<Post> Boxes { get; set; }
    }
}
