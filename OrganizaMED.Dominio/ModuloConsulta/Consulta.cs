using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrganizaMED.Dominio.Compartilhado;
using OrganizaMED.Dominio.ModuloMedico;

namespace OrganizaMED.Dominio.ModuloConsulta
{
    public class Consulta : Entidade
    {
        public DateTime Data { get; set; }
        public int Duracao { get; set; }
        public Medico Medico { get; set; }

        public Consulta()
        {
            
        }
        public Consulta(DateTime data, int duracao, Medico medico)
        {
            Data = data;
            Duracao = duracao;
            Medico = medico;
        }
    }
}