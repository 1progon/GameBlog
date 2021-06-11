using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using GameBlog.Models.Base;
using GameBlog.Models.Blog;

namespace GameBlog.Models.Users
{
    public class User : IdentityUser<int>, IBaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string Name { get; set; }

        public string Slug { get; set; }

        public bool Active { get; set; }

        public Moderation Moderation { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int? Age { get; set; }

        public bool RememberMe { get; set; }

        public bool TermsAndConditions { get; set; }


        public ICollection<Post> BlogPosts { get; set; }
        public ICollection<Category> BlogCategories { get; set; }
    }
}