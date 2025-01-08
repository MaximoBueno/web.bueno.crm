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
    public class ContactoTelefonoRepository : IContactoTelefonoRepository
    {
        private readonly CrmLiaContext _context;

        public ContactoTelefonoRepository(CrmLiaContext context)
        {
            _context = context;
        }
       
        public async Task<bool> CrearContactoTelefono(ContactoTelefono telefono)
        {
            await _context.ContactoTelefono.AddAsync(telefono);
            var returned = await _context.SaveChangesAsync();
            return returned > 0 ? true : false;
        }

        public async Task<bool> EditarContactoTelefono(ContactoTelefono telefono)
        {
            _context.ContactoTelefono.Update(telefono);
            var returned = await _context.SaveChangesAsync();
            return returned > 0 ? true : false;
        }

        public async Task<List<ContactoTelefono>> BuscarTelefonosPorIdContacto(long IdContacto)
        {
            return await _context.ContactoTelefono.Where(x => x.IdContacto == IdContacto).ToListAsync();
        }
    }
}
