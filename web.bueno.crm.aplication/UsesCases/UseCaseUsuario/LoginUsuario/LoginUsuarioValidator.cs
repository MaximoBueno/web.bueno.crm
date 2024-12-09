using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace web.bueno.crm.aplication.UsesCases.UseCaseUsuario.LoginUsuario
{
    public class LoginUsuarioValidator : AbstractValidator<LoginUsuarioRequest>
    {
        public LoginUsuarioValidator() {
            RuleFor(x => x.Correo).NotEmpty().WithMessage("El correo es requerido.");
            RuleFor(x => x.Clave).NotEmpty().WithMessage("La clave es requerida");
        }
    }
}
