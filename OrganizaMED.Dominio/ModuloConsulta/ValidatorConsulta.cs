using FluentValidation;
using OrganizaMED.Dominio.ModuloCirugia;
using System;
using System.Collections.Generic;
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

            RuleFor(x => x.Data).NotEmpty().WithMessage("A data de inicio é obrigatória");
        }
    }
}
