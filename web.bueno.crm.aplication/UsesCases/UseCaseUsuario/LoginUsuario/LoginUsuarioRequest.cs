using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.bueno.crm.aplication.Common;

namespace web.bueno.crm.aplication.UsesCases.UseCaseUsuario.LoginUsuario
{
    public class LoginUsuarioRequest : IRequest<IResult>
    {
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}
