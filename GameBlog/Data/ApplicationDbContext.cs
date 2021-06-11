using GameBlog.Data.EntityConfiguration.Blog;
using GameBlog.Data.EntityConfiguration.User;
using GameBlog.Models;
using GameBlog.Models.Blog;
using GameBlog.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public override DbSet<User> Users { get; set; }

        public DbSet<Category> BlogCategories { get; set; }
        public DbSet<Post> BlogPosts { get; set; }
        public DbSet<PostImage> BlogPostImages { get; set; }

        public DbSet<Newsletter> Newsletters { get; set; }

        public DbSet<ContactMessage> ContactMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new BlogCategoryConfiguration());
            builder.ApplyConfiguration(new BlogPostConfiguration());
            builder.ApplyConfiguration(new BlogPostImageConfiguration());
        }
    }
}