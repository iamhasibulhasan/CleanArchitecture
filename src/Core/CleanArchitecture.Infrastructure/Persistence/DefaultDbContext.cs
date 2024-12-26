using CleanArchitecture.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArchitecture.Infrastructure.Persistence;

public sealed class DefaultDbContext : DbContext
{
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Education> Educations { get; set; }

    // This is for entity (configuration) reading 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
