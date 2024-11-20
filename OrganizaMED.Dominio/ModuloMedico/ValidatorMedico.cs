using FluentValidation;
using OrganizaMED.Dominio.ModuloCirugia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizaMED.Dominio.ModuloMedico
{
    public class ValidatorMedico : AbstractValidator<Medico>
    {
        public ValidatorMedico()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório").MinimumLength(3)
                .WithMessage("O nome deve possuir no mínimo 3 caracteres.")
                .MaximumLength(100).WithMessage("O nome deve possuir no máximo 100 caracteres");

            RuleFor(x => x.CRM).NotEmpty()
                .WithMessage("A CRM é obrigatória.");

        }

    }
}
