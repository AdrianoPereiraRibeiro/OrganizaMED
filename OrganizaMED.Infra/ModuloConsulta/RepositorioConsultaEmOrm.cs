using Microsoft.Win32;
using NoteKeeper.Infra.Orm.Compartilhado;
using OrganizaMED.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganizaMED.Dominio.ModuloConsulta;
using Microsoft.EntityFrameworkCore;

namespace OrganizaMED.Infra.ModuloConsulta
{
    public class RepositorioConsultaOrm : RepositorioBase<Consulta>, IRepositorioConsulta
    {
        public RepositorioConsultaOrm(IContextoPersistencia dbContext) : base(dbContext)
        {
        }

        public override Consulta SelecionarPorId(Guid id)
        {
            return registros.Include(x => x.Medico).SingleOrDefault(x => x.Id == id);
        }

        public override async Task<Consulta> SelecionarPorIdAsync(Guid id)
        {
            return await registros.Include(x => x.Medico).SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
