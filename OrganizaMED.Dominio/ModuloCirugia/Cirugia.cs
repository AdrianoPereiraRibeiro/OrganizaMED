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
        public DateTime Data { get; set; }  
        public int Duracao { get; set; }
        public Medico Medico { get; set; }


        public Cirugia() { }
        public Cirugia(DateTime data, int duracao, Medico medico)
        {
            Data = data;
            Duracao = duracao;
            Medico = medico;
        }
    }
}