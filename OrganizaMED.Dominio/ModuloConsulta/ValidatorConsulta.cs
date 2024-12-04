using FluentValidation;
using OrganizaMED.Dominio.ModuloCirugia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizaMED.Dominio.ModuloConsulta
{
    public class ValidatorConsulta : AbstractValidator<Consulta>
    {
        public ValidatorConsulta()
        {
            RuleFor(x => x.Medico)
                .NotEmpty().WithMessage("O médico é obrigatório");

            RuleFor(x => x.Duracao).NotEmpty().NotNull().GreaterThan(0)
                .WithMessage("A duração não deve ser igual ou menor do que 0.");

            RuleFor(x => x.DataDeInicio).NotEmpty().WithMessage("A data de inicio é obrigatória");

            RuleFor(x => x).Must(NaoCoincidirComOutrasConsultas)
                .WithMessage("O horário da consulta coincide com outra atividade agendada para este médico.");
        }

        private bool NaoCoincidirComOutrasConsultas(Consulta consulta)
        {
            
            var agenda = consulta.Medico.Agenda;

            
            foreach (var c in agenda)
            {
                if (c <= consulta.DataDeInicio && c <= consulta.DataDeEncerramento)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
