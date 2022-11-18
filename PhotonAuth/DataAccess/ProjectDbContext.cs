using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PhotonAuth.Models;

namespace PhotonAuth.DataAccess;

public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options, IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
    }

    protected ProjectDbContext(DbContextOptions options, IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
    }

    protected IConfiguration Configuration { get; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            base.OnConfiguring(
                optionsBuilder.UseNpgsql(
                    Configuration.GetConnectionString("PgSql")
                    ?? throw new NullReferenceException("Assign connection string in appsettings.json")
                ).EnableSensitiveDataLogging());
        }
    }
}