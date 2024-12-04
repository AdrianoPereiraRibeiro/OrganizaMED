using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OrganizaMED.Dominio.Compartilhado;
using OrganizaMED.Dominio.ModuloMedico;

namespace OrganizaMED.Dominio.ModuloCirugia
{
    public class Cirugia : Entidade
    {
        public DateTime DataDeInicio { get; set; }  
        public DateTime DataDeEncerramento { get; set; }
        public int Duracao { get; set; }
        public List<Medico> Medicos { get; set; }

        public IRepositorioMedico RepositorioMedico;

        public Cirugia() { }
        public Cirugia(DateTime dataDeInicio, int duracao, List<Medico> medicos)
        {
            DataDeInicio = dataDeInicio;
            DataDeEncerramento = dataDeInicio.AddMinutes(Duracao);
            Duracao = duracao;
            Medicos = medicos;
        }

        public void atualizarTermino()
        {
            DataDeEncerramento = DataDeInicio.AddMinutes(Duracao);
        }

        public void prencherMedicos(String[] ids)
        {
            foreach (var m in RepositorioMedico.SelecionarTodosAsync().Result )
            {
                if (m.Id.Equals(ids))
                {
                    Medicos.Add(m);
                }
            }
        }
    }
}