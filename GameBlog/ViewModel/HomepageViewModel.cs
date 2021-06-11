using System.Collections.Generic;
using GameBlog.Models.Blog;

namespace GameBlog.ViewModel
{
    public class HomepageViewModel
    {
        public IEnumerable<Post> BlogPosts { get; set; }
    }
}