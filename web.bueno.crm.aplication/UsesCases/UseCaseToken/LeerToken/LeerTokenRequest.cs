using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using web.bueno.crm.aplication.Common;

namespace web.bueno.crm.aplication.UsesCases.UseCaseToken.LeerToken
{
    public class LeerTokenRequest : IRequest<IResult>
    {
        public string Token { get; set; }
    }
}
