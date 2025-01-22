using Havalan.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Havalan.Infrastructure.Users.Persistence;
public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(d => d.CreationDate).IsRequired();

        builder.HasIndex(u => u.UserName).IsUnique();
        builder.Property(u => u.UserName).IsRequired();
        builder.Property(f => f.FullName).IsRequired();
        builder.Property(f => f.Password).IsRequired();
        builder.Property(r => r.Roles).IsRequired();
    }
}