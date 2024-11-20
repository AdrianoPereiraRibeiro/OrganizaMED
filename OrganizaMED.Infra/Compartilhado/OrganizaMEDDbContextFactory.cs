using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OrganizaMED.Infra.Orm.Compartilhado
{
    public class OrganizaMEDDbContextFactory : IDesignTimeDbContextFactory<OrganizaMEDDbContext>
    {
        public OrganizaMEDDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrganizaMEDDbContext>();

            IConfiguration configuracao = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new OrganizaMEDDbContext(optionsBuilder.Options);

            return dbContext;
        }
    }
}
