using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace web.bueno.crm.aplication.UsesCases.UseCaseContacto.CrearContacto
{
    public class CrearContactoValidator : AbstractValidator<CrearContactoRequest>
    {
        public CrearContactoValidator() {
            RuleFor(x => x.Nombres).NotEmpty().WithMessage("Los nombres no deben estar vacios.");
            RuleFor(x => x.ApellidoPaterno).NotEmpty().WithMessage("El apellido paterno no debe estar vacio.");
            RuleFor(x => x.ApellidoMaterno).NotEmpty().WithMessage("El apellido materno no debe  estar vacio.");
        }
    }

    public class CrearContactoCorreoValidator : AbstractValidator<CrearContactoCorreoRequest>
    {
        public CrearContactoCorreoValidator()
        {
            RuleFor(x => x.Correo).NotEmpty().WithMessage("El correo no debe estar vacio.");
        }
    }
    public class CrearContactoTelefonoValidator : AbstractValidator<CrearContactoTelefonoRequest>
    {
        public CrearContactoTelefonoValidator()
        {
            RuleFor(x => x.NumeroTelefono).NotEmpty().WithMessage("El número no debe estar vacio.");
        }
    }
}
