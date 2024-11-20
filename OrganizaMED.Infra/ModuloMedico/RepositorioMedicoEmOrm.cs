using Microsoft.Win32;
using NoteKeeper.Infra.Orm.Compartilhado;
using OrganizaMED.Dominio.Compartilhado;
using OrganizaMED.Dominio.ModuloConsulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrganizaMED.Dominio.ModuloMedico;

namespace OrganizaMED.Infra.ModuloMedico
{
    public class RepositorioMedicoOrm : RepositorioBase<Medico>, IRepositorioMedico
    {
        public RepositorioMedicoOrm(IContextoPersistencia dbContext) : base(dbContext)
        {
        }

        public override Medico SelecionarPorId(Guid id)
        {
            return registros.SingleOrDefault(x => x.Id == id);
        }

        public override async Task<Medico> SelecionarPorIdAsync(Guid id)
        {
            return await registros.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
