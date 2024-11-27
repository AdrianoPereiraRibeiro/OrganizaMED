using Microsoft.EntityFrameworkCore;
using OrganizaMED.Dominio.Compartilhado;
using OrganizaMED.Infra.ModuloCirugia;
using OrganizaMED.Infra.ModuloConsulta;
using OrganizaMED.Infra.ModuloMedico;


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
            modelBuilder.ApplyConfiguration(new MapeadorMedicoOrm());

            modelBuilder.ApplyConfiguration(new MapeadorConsultaOrm());
            modelBuilder.ApplyConfiguration(new MapeadorCirugiaOrm());

            base.OnModelCreating(modelBuilder);
        }

    }
}
