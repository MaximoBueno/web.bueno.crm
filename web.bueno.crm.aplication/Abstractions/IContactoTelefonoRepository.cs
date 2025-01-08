using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.bueno.crm.domain.sql;

namespace web.bueno.crm.aplication.Abstractions
{
    public interface IContactoTelefonoRepository
    {
        Task<bool> CrearContactoTelefono(ContactoTelefono telefono);
        Task<bool> EditarContactoTelefono(ContactoTelefono telefono);
        Task<List<ContactoTelefono>> BuscarTelefonosPorIdContacto(long IdContacto);
    }
}
