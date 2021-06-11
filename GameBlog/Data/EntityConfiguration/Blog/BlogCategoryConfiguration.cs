using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameBlog.Models.Blog;

namespace GameBlog.Data.EntityConfiguration.Blog
{
    public class BlogCategoryConfiguration : IEntityTypeConfiguration<Category>

    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasMany(c => c.Posts)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.BlogCategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(c => c.Author)
                .WithMany(u => u.BlogCategories)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .Property(c => c.Slug)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder
                .HasIndex(c => c.Slug)
                .IsUnique();
        }
    }
}