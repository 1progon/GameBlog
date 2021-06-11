using System;
using GameBlog.Models.Base;

namespace GameBlog.Models.Blog
{
    public class PostImage : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public int BlogPostId { get; set; }
        public Post Post { get; set; }

        public string Folder { get; set; }
        public string Extension { get; set; }
    }
}