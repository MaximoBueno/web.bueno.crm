using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace web.bueno.crm.aplication.UsesCases.UseCaseToken.LeerToken
{
    public class LeerTokenValidator: AbstractValidator<LeerTokenRequest>
    {
        public LeerTokenValidator() {
            RuleFor(x => x.Token).NotEmpty().WithMessage("El token no debe de estar vacio");
        
        }
    }
}
