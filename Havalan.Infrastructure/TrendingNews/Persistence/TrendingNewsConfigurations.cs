using Havalan.Domain.TrendingNews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Havalan.Infrastructure.TrendingNews.Persistence;
public class TrendingNewsConfigurations : IEntityTypeConfiguration<TrendingNew>
{
    public void Configure(EntityTypeBuilder<TrendingNew> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(d => d.CreationDate).IsRequired();

        builder.Property(t => t.Title).IsRequired();
    }
}