using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizaMED.Dominio.ModuloCirugia
{
    public class ValidadorCirugia : AbstractValidator<Cirugia>
    {
        public ValidadorCirugia()
        {
            RuleFor(x => x.Medicos)
                .NotEmpty().WithMessage("O médico é obrigatório");

            RuleFor(x => x.Duracao).NotEmpty().NotNull().GreaterThan(0)
                .WithMessage("A duração não deve ser igual ou menor do que 0.");

            RuleFor(x => x.DataDeInicio).NotEmpty().WithMessage("A data de inicio é obrigatória");
        }

    }
}
