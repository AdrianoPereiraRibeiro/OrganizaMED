using Microsoft.EntityFrameworkCore;
using OrganizaMED.Dominio.Compartilhado;
using OrganizaMED.Infra.Orm.Compartilhado;

namespace NoteKeeper.Infra.Orm.Compartilhado
{
    public class RepositorioBase<TEntidade> where TEntidade : Entidade
    {
        protected OrganizaMEDDbContext dbContext;
        protected DbSet<TEntidade> registros;

        public RepositorioBase(IContextoPersistencia ctx)
        {
            this.dbContext = (OrganizaMEDDbContext)ctx;
            this.registros = dbContext.Set<TEntidade>();
        }

        public async Task<bool> InserirAsync(TEntidade registro)
        {
            await registros.AddAsync(registro);

            await dbContext.SaveChangesAsync();

            return true;
        }

        public void Editar(TEntidade registro)
        {
            registros.Update(registro);

            dbContext.SaveChanges();
        }

        public void Excluir(TEntidade registro)
        {
            registros.Remove(registro);

            dbContext.SaveChanges();
        }

        public virtual TEntidade SelecionarPorId(Guid id)
        {
            return registros.SingleOrDefault(x => x.Id == id);
        }

        public async virtual Task<TEntidade> SelecionarPorIdAsync(Guid id)
        {
            return await registros.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TEntidade>> SelecionarTodosAsync()
        {
            return await registros.ToListAsync();
        }

    }
}
