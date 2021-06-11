using System;
using System.Collections.Generic;
using GameBlog.Models.Base;
using GameBlog.Models.Users;

namespace GameBlog.Models.Blog
{
    public class Category : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public string Description { get; set; }

        public ICollection<Post> Posts { get; set; }

        public int UserId { get; set; }
        public User Author { get; set; }
    }
}