using CodeBase.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodeBase.Infrastructure.AppDbContext
{
    public class CodebaseDbContext : DbContext
    {
        public CodebaseDbContext(DbContextOptions<CodebaseDbContext> options) : base(options)
        {
        }

        // Register model entity to DbContext using DbSet
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CodebaseDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

