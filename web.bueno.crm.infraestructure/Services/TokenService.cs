using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using web.bueno.crm.aplication.Services;
using web.bueno.crm.domain.sql;

namespace web.bueno.crm.infraestructure.Services
{
    public class TokenService : ITokenService
    {
        public const string SECRET_DEFAULT = "8DVT4inMYFCCb6880S5h8GF78ztMREHSYNCKwe";
        public const double EXPIRE_HOURS_DEFAULT = 8.0;

        public string CreateToken(Usuario user)
        {
            var key = Encoding.UTF8.GetBytes(SECRET_DEFAULT);

            var handler = new JwtSecurityTokenHandler();

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Correo),
                        new Claim(ClaimTypes.Role, user.Roles)
                    }
                ),
                Expires = DateTime.UtcNow.AddHours(EXPIRE_HOURS_DEFAULT),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = handler.CreateToken(descriptor);

            return handler.WriteToken(token);
        }
    }
}
