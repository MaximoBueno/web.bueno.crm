using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.bueno.crm.domain.sql;

namespace web.bueno.crm.aplication.UsesCases.UseCaseUsuario.LoginUsuario
{
    public class LoginUsuarioMapper : Profile
    {
        public LoginUsuarioMapper() { 
            CreateMap<LoginUsuarioRequest,Usuario>();
        }
    }
}
