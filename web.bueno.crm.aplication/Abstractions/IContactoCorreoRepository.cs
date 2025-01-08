using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.bueno.crm.domain.sql;

namespace web.bueno.crm.aplication.Abstractions
{
    public interface IContactoCorreoRepository
    {
        Task<bool> CrearContactoCorreo(ContactoCorreo correo);
        Task<bool> EditarContactoCorreo(ContactoCorreo correo);
        Task<List<ContactoCorreo>> BuscarCorreosPorIdContacto(long IdContacto);
    }
}
