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



        public Cirugia()
        {
            Medicos = new List<Medico>();}
        public Cirugia(DateTime dataDeInicio, int duracao)
        {
            DataDeInicio = dataDeInicio;
            DataDeEncerramento = dataDeInicio.AddMinutes(Duracao);
            Duracao = duracao;
            Medicos = new List<Medico>();
        }

        public void atualizarTermino()
        {
            DataDeEncerramento = DataDeInicio.AddMinutes(Duracao);
        }

        public void prencherMedicos(IEnumerable<Guid> ids,List<Medico> medicos)
        {
            foreach (var m in medicos)
            {
                foreach (var id in ids)
                {
                    if (m.Id.Equals(id))
                    {
                        Medicos.Add(m);
                    }

                }
                
            }
        }
    }
}