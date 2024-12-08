using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.bueno.crm.domain.sql;

namespace web.bueno.crm.aplication.Abstractions
{
    public interface IContactoRepository
    {
        Task<Contacto> CrearContacto(Contacto contacto);
        Task<bool> EditarContacto(Contacto contacto);
        Task<Contacto> BuscarContactoPorIdContactoIdGestor(long IdContacto, long IdGestor);
        Task<long> CantidadContactoPorIdGestor(long IdGestor);
        Task<List<Contacto>> ListarContactoPorIdGestor(long IdGestor, int page, int limit);

    }
}
