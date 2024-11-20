using Microsoft.Win32;
using NoteKeeper.Infra.Orm.Compartilhado;
using OrganizaMED.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrganizaMED.Dominio.ModuloCirugia;

namespace OrganizaMED.Infra.ModuloCirugia
{
    public class RepositorioCirugiaOrm : RepositorioBase<Cirugia>, IRepositorioCirugia
    {
        public RepositorioCirugiaOrm(IContextoPersistencia dbContext) : base(dbContext)
        {
        }

        public override Cirugia SelecionarPorId(Guid id)
        {
            return registros.Include(x => x.Medicos).SingleOrDefault(x => x.Id == id);
        }

        public override async Task<Cirugia> SelecionarPorIdAsync(Guid id)
        {
            return await registros.Include(x => x.Medicos).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
