using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using web.bueno.crm.aplication.Common;
using MediatR;

namespace web.bueno.crm.aplication.UsesCases.UseCaseToken.RefreshToken
{
    public class RefreshTokenRequest : IRequest<IResult>
    {
        public string Token { get; set; }

    }
}
