using System.Collections.Generic;
using GameBlog.Models;
using GameBlog.Models.Blog;

namespace GameBlog.ViewModel.Blog
{
    public class BlogPostIndexViewModel
    {
        public IEnumerable<Post> BlogPosts { get; set; }
        public Pagination Pagination { get; set; }
    }
}