using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace web.bueno.crm.aplication.UsesCases.UseCaseContacto.ListarContactoPorGestor
{
    public class ListarContactoPorGestorValidator : AbstractValidator<ListarContactoPorGestorRequest>
    {

        public ListarContactoPorGestorValidator() {
            RuleFor(x => x.IdGestor).GreaterThan(0).WithMessage("El Id debe ser valido.");
        }

    }
}
