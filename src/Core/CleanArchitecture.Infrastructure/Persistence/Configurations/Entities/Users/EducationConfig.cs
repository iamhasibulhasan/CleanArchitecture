using CleanArchitecture.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations.Entities.Users
{
    public sealed class EducationConfig : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.ToTable("Educations", "public");
            builder.HasKey(k => k.Id);

            builder.Property(k => k.Degree)
            .IsRequired()
            .HasMaxLength(200);
            builder.Property(k => k.InstitutionName)
            .IsRequired();
            builder.Property(k => k.FieldOfStudy)
            .IsRequired();

            builder.HasOne(k => k.User)
                .WithMany()
                .HasForeignKey(k => k.UserId);
        }
    }
}
