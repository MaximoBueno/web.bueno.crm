using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.bueno.crm.aplication.UsesCases.UseCaseToken.LeerToken;
using web.bueno.crm.aplication.UsesCases.UseCaseToken.RefreshToken;
using web.bueno.crm.domain.sql;

namespace web.bueno.crm.aplication.Services
{
    public interface ITokenService
    {
        string CreateToken(Usuario user,bool refresh);
        LeerTokenResponse ReadToken(LeerTokenRequest req);
    }
}
