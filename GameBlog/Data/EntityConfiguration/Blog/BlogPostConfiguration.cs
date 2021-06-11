using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameBlog.Models.Blog;

namespace GameBlog.Data.EntityConfiguration.Blog
{
    public class BlogPostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.BlogCategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(p => p.Author)
                .WithMany(u => u.BlogPosts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasMany(p => p.BlogPostImages)
                .WithOne(i => i.Post)
                .HasForeignKey(i => i.BlogPostId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .Property(p => p.Slug)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder
                .Property(p => p.Image)
                .HasColumnType("varchar(255)");


            builder
                .HasIndex(p => p.Slug)
                .IsUnique();
        }
    }
}