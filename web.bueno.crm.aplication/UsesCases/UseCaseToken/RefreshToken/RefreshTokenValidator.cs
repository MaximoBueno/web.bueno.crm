using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace web.bueno.crm.aplication.UsesCases.UseCaseToken.RefreshToken
{
    public class RefreshTokenValidator : AbstractValidator<RefreshTokenRequest>
    { 
        public RefreshTokenValidator() {
            RuleFor(x => x.Token).NotEmpty().WithMessage("El token no debe de estar vacio");
        }
    }
}
