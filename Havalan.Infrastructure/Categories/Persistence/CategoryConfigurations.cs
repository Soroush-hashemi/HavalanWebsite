using Havalan.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Havalan.Infrastructure.Categories.Persistence;
public class CategoryConfigurations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(d => d.CreationDate).IsRequired();
        builder.HasIndex(s => s.Slug);
        builder.Property(s => s.Slug).IsRequired().IsUnicode(false);
        builder.Property(t => t.Title).IsRequired();

        builder.HasMany(b => b.SubCategory)
            .WithOne().HasForeignKey(b => b.ParentId);
    }
}