using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Owner.Example
{
    public class OwnerContext : DbContext
    {
        public OwnerContext(DbContextOptions<OwnerContext> dbContextOptions) : base(dbContextOptions) { }

        public const string Schema = "owner";

        public DbSet<Parent> Parents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(OwnerContext)));
        }
    }

    public class OwnerContextFactory : IDesignTimeDbContextFactory<OwnerContext>
    {
        public OwnerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OwnerContext>();
            optionsBuilder.UseSqlServer(
                "Server=tcp:localhost,1433;Initial Catalog=EfOwnerTest;Persist Security Info=False;User ID=sa;Password=mvDev1234!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

            return new OwnerContext(optionsBuilder.Options);
        }
    }
}