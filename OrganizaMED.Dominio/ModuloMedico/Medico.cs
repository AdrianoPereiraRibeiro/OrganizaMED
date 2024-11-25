using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrganizaMED.Dominio.Compartilhado;
using OrganizaMED.Dominio.ModuloCirugia;

namespace OrganizaMED.Dominio.ModuloMedico
{
    public class Medico: Entidade
    {
        public string Nome { get; set; }
        public string CRM { get; set; }
        public List<DateTime>? Agenda { get; set; }
    }
}