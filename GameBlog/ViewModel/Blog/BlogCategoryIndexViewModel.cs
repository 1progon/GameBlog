using System.Collections.Generic;
using GameBlog.Models;
using GameBlog.Models.Blog;

namespace GameBlog.ViewModel.Blog
{
    public class BlogCategoryIndexViewModel
    {
        public IEnumerable<Category> BlogCategories { get; set; }
        public Pagination Pagination { get; set; }
    }
}