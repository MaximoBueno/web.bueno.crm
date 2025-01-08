using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.bueno.crm.aplication.Abstractions;
using web.bueno.crm.domain.sql;
using web.bueno.crm.infraestructure.Contexts;

using Microsoft.EntityFrameworkCore;

namespace web.bueno.crm.infraestructure.Repositories
{
    public class ContactoDireccionRepository : IContactoDireccionRepository
    {
        private readonly CrmLiaContext _context;

        public ContactoDireccionRepository(CrmLiaContext context)
        {
            _context = context;
        }

        public async Task<bool> CrearContactoDireccion(ContactoDireccion direccion)
        {
            await _context.ContactoDireccion.AddAsync(direccion);
            var returned = await _context.SaveChangesAsync();
            return returned > 0 ? true : false;
        }

        public async Task<bool> EditarContactoDireccion(ContactoDireccion direccion)
        {
            _context.ContactoDireccion.Update(direccion);
            var returned = await _context.SaveChangesAsync();
            return returned > 0 ? true : false;
        }

        public async Task<List<ContactoDireccion>> BuscarDireccionesPorIdContacto(long IdContacto)
        {
            return await _context.ContactoDireccion.Where(x => x.IdContacto == IdContacto).ToListAsync();
        }

    }
}
