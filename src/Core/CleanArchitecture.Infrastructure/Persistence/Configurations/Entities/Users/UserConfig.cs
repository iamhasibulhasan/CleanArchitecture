using CleanArchitecture.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations.Entities.Users;

public sealed class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "public");
        builder.HasKey(k => k.Id);

        builder.Property(k => k.UserCode)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(k => k.FirstName)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(k => k.LastName)
            .HasMaxLength(200);
        builder.Property(k => k.Email)
            .IsRequired();
        builder.Property(k => k.Phone)
            .IsRequired();
    }
}
