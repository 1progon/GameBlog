using System.Collections.Generic;
using GameBlog.Models;
using GameBlog.Models.Blog;

namespace GameBlog.ViewModel.Blog
{
    public class BlogIndexViewModel
    {
        public IEnumerable<Post> BlogPosts { get; set; }
        public IEnumerable<Category> BlogCategories { get; set; }

        public Pagination PostPagination { get; set; }
    }
}