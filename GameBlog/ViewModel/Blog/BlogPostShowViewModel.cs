using System;
using System.Collections.Generic;
using GameBlog.Models.Blog;
using GameBlog.Models.Users;

namespace GameBlog.ViewModel.Blog
{
    public class BlogPostShowViewModel
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public string Description { get; set; }

        public string Article { get; set; }
        
        public string Image { get; set; }

        public ICollection<PostImage> BlogPostImages { get; set; }

        public Category Category { get; set; }

        public User Author { get; set; }

        public int? Views { get; set; }
    }
}