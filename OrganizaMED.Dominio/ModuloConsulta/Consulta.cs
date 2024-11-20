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
        public DateTime DataDeInicio { get; set; }
        public DateTime DataDeEncerramento { get; set; }
        public int Duracao { get; set; }
        public Medico Medico { get; set; }



        public Consulta() { }
        public Consulta(DateTime dataDeInicio, int duracao, Medico medico)
        {
            DataDeInicio = dataDeInicio;
            DataDeEncerramento = dataDeInicio.AddMinutes(Duracao);
            Duracao = duracao;
            Medico = medico;
        }
    }
}