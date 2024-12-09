using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using web.bueno.crm.aplication.Common;
using MediatR;

namespace web.bueno.crm.aplication.UsesCases.UseCaseContacto.ListarContactoPorGestor
{
    public class ListarContactoPorGestorRequest : IRequest<IResult>
    {
        public long IdGestor { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
