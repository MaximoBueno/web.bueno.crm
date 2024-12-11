using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace web.bueno.crm.aplication.UsesCases.UseCaseContacto.EditarContacto
{
    public class EditarContactoValidator : AbstractValidator<EditarContactoRequest>
    {
        public EditarContactoValidator() {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("El Id deben ser valido.");
            RuleFor(x => x.Nombres).NotEmpty().WithMessage("Los nombres no deben estar vacios.");
            RuleFor(x => x.ApellidoPaterno).NotEmpty().WithMessage("El apellido paterno no debe estar vacio.");
            RuleFor(x => x.ApellidoMaterno).NotEmpty().WithMessage("El apellido materno no debe  estar vacio.");
        }
    }
}
