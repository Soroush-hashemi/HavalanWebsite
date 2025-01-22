using Havalan.Domain.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Havalan.Infrastructure.Comments.Persistence;
public class CommentConfigurations : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(c => c.CreationDate).IsRequired();
        builder.HasIndex(i => i.PostId);
        builder.Property(u => u.UserName).IsRequired();
        builder.Property(t => t.Text).IsRequired();
    }
}