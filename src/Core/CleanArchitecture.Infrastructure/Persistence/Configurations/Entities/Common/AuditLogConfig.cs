using CleanArchitecture.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations.Entities.Common
{
    public sealed class AuditLogConfig : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.ToTable("AuditLogs", "public");
            builder.HasKey(k => k.Id);

            builder.Property(k => k.Data)
                .IsRequired();
            builder.Property(e => e.CreatedDate)
                .HasDefaultValueSql("NOW()");
        }
    }
}
