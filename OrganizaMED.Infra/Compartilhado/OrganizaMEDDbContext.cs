using Microsoft.EntityFrameworkCore;
using OrganizaMED.Dominio.Compartilhado;


namespace OrganizaMED.Infra.Orm.Compartilhado
{
    public class OrganizaMEDDbContext : DbContext, IContextoPersistencia
    {
        public OrganizaMEDDbContext(DbContextOptions options) : base(options)
        {
        }      

        public async Task<bool> GravarAsync()
        {
            await SaveChangesAsync();
            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new MapeadorCategoriaOrm());

            //modelBuilder.ApplyConfiguration(new MapeadorNotaOrm());

            base.OnModelCreating(modelBuilder);
        }

    }
}
