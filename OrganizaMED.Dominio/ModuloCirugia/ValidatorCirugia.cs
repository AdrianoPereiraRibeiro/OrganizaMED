using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganizaMED.Dominio.ModuloConsulta;

namespace OrganizaMED.Dominio.ModuloCirugia
{
    public class ValidatorCirugia : AbstractValidator<Cirugia>
    {
        public ValidatorCirugia()
        {
            RuleFor(x => x.Medicos)
                .NotEmpty().WithMessage("O médico é obrigatório");

            RuleFor(x => x.Duracao).NotEmpty().NotNull().GreaterThan(0)
                .WithMessage("A duração não deve ser igual ou menor do que 0.");

            RuleFor(x => x).Must(NaoCoincidirComOutrasConsultas)
                .WithMessage("O horário da consulta coincide com outra atividade agendada para este médico.");
        }

        private bool NaoCoincidirComOutrasConsultas(Cirugia cirugia)
        {

            

            foreach (var m in cirugia.Medicos)
            {
                var agenda = m.Agenda;
            foreach (var c in agenda)
            {
                if (c <= cirugia.DataDeInicio && c <= cirugia.DataDeEncerramento)
                {
                    return false;
                }
            }
            }
            return true;
        }
    }
}
