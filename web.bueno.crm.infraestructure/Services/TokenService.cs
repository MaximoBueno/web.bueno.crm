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
        public const string SECRET_DEFAULT = "PRUEBAKEYSECRET_PRUEBAKEYSECRET_PRUEBAKEYSECRET";
        public const double EXPIRE_HOURS_DEFAULT = 8.0;

        public string CreateToken(Usuario user)
        {
            var key = Encoding.ASCII.GetBytes(SECRET_DEFAULT);

            var claim = new Claim[]{
                new Claim(ClaimTypes.Name, user.Correo),
                new Claim(ClaimTypes.Role, user.Roles)
            };

            var securityKey = new SymmetricSecurityKey(key);

            var singningCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var securityToken = new JwtSecurityToken(
                claims: claim.AsEnumerable(),
                expires: DateTime.Now.AddHours(EXPIRE_HOURS_DEFAULT),
                issuer: "",
                audience: "",
                signingCredentials: singningCred
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return tokenString;
        }
    }
}
