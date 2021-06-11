using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameBlog.Models.Blog;

namespace GameBlog.Data.EntityConfiguration.Blog
{
    public class BlogPostImageConfiguration : IEntityTypeConfiguration<PostImage>
    {
        public void Configure(EntityTypeBuilder<PostImage> builder)
        {
            builder
                .Property(i => i.Slug)
                .HasColumnType("varchar(255)")
                .IsRequired();
        }
    }
}