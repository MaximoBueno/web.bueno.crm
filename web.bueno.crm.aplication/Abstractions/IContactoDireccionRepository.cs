using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.bueno.crm.domain.sql;

namespace web.bueno.crm.aplication.Abstractions
{
    public interface IContactoDireccionRepository
    {
        Task<bool> CrearContactoDireccion(ContactoDireccion direccion);
        Task<bool> EditarContactoDireccion(ContactoDireccion direccion);
        Task<List<ContactoDireccion>> BuscarDireccionesPorIdContacto(long IdContacto);
    }
}
