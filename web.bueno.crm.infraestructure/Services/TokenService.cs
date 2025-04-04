﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using web.bueno.crm.aplication.Services;
using web.bueno.crm.aplication.UsesCases.UseCaseToken.LeerToken;
using web.bueno.crm.aplication.UsesCases.UseCaseToken.RefreshToken;
using web.bueno.crm.domain.sql;
using web.bueno.crm.infraestructure.Data;

namespace web.bueno.crm.infraestructure.Services
{
    public class TokenService : ITokenService
    {

        public readonly TokenSettingOptions _options;

        public TokenService(IOptions<TokenSettingOptions> options) {
            _options = options.Value;
        }

        public string CreateToken(Usuario user, bool refresh)
        {

            var key = Encoding.UTF8.GetBytes(_options.Key);

            var handler = new JwtSecurityTokenHandler();

            var inicio = DateTime.UtcNow;
            var expire = inicio.AddHours((refresh == true ? _options.DurationHoursRefresh : _options.DurationHours));

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user, refresh, inicio, expire),

              
                Expires = expire,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = handler.CreateToken(descriptor);

            return handler.WriteToken(token);
        }


        private ClaimsIdentity GenerateClaims(Usuario user, bool refresh, DateTime inicio, DateTime expire)
        {

            var Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Correo),
                        new Claim(ClaimTypes.Role, user.Roles),
                        new Claim("ulo", user.Correo),
                        new Claim("uid", user.Id.ToString()),
                        new Claim("uno", user.NombreCompleto),
                        new Claim("upe", user.Roles),
                        new Claim("fei", inicio.ToString()),
                        new Claim("fee", expire.ToString()),
                    }
             );

            if (refresh)
            {
                Subject.AddClaim(new Claim("refresh", refresh.ToString()));
            }

            return Subject;
        }

        public LeerTokenResponse ReadToken(LeerTokenRequest req)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var readToken = tokenHandler.ReadJwtToken(req.Token);
            return new LeerTokenResponse { Payload = readToken.Payload.ToDictionary<string, object>() };
        }
    }
}
