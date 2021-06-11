using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GameBlog.Models.Users;

namespace GameBlog.Data.EntityConfiguration.User
{
    public class UserConfiguration : IEntityTypeConfiguration<Models.Users.User>
    {
        public void Configure(EntityTypeBuilder<Models.Users.User> builder)
        {
            builder
                .Property(u => u.Email)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder
                .HasIndex(u => u.Email)
                .IsUnique();

            builder
                .Property(u => u.TermsAndConditions)
                .HasDefaultValue(false)
                .IsRequired();


            builder
                .Property(u => u.Moderation)
                .HasDefaultValue((Moderation) 0);

            builder
                .Property(u => u.Slug)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder
                .HasIndex(u => u.Slug)
                .IsUnique();

            builder
                .Property(u => u.Active)
                .HasDefaultValue(false);
        }
    }
}