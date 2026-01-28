using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using HRManagement.Infrastructure.Persistence;

namespace Api
{
    // Design-time factory for EF Core tools to create AppDbContext when running migrations from the Api project
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite("Data Source=hr.db", b => b.MigrationsAssembly("Api"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
