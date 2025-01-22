using Havalan.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Havalan.Infrastructure.Posts.Persistence;
public class PostConfigurations : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(d => d.CreationDate).IsRequired();

        builder.HasIndex(b => b.Slug).IsUnique();
        builder.Property(b => b.CategoryId).IsRequired();
        builder.Property(b => b.SubCategoryId).IsRequired();
        builder.Property(b => b.Title).IsRequired().HasMaxLength(200);
        builder.Property(b => b.Description).IsRequired();
        builder.Property(b => b.ImageName)
            .IsRequired().HasMaxLength(3000).HasMaxLength(3000);

        builder.Property(b => b.Slug).IsRequired().IsUnicode(false);
    }
}