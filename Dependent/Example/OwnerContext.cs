using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Dependent.Example
{
    public class DependentContext : DbContext
    {
        public DependentContext(DbContextOptions<DependentContext> dbContextOptions) : base(dbContextOptions) { }

        public const string Schema = "Dependent";

        public DbSet<Parent> Parents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(DependentContext)));
        }
    }

    public class DependentContextFactory : IDesignTimeDbContextFactory<DependentContext>
    {
        public DependentContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DependentContext>();
            optionsBuilder.UseSqlServer(
                "Server=tcp:localhost,1433;Initial Catalog=EfDependentTest;Persist Security Info=False;User ID=sa;Password=mvDev1234!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

            return new DependentContext(optionsBuilder.Options);
        }
    }
}