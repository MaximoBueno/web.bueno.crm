using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.bueno.crm.aplication.Abstractions;
using web.bueno.crm.domain.sql;
using web.bueno.crm.infraestructure.Contexts;

using Microsoft.EntityFrameworkCore;

namespace web.bueno.crm.infraestructure.Repositories
{
    public class ContactoCorreoRepository : IContactoCorreoRepository
    {
        private readonly CrmLiaContext _context;

        public ContactoCorreoRepository(CrmLiaContext context)
        {
             _context = context;
        }
      
        public async Task<bool> CrearContactoCorreo(ContactoCorreo correo)
        {
            await _context.ContactoCorreo.AddAsync(correo);
            var returned = await _context.SaveChangesAsync();
            return returned > 0 ? true : false;
        }

        public async Task<bool> EditarContactoCorreo(ContactoCorreo correo)
        {
            _context.ContactoCorreo.Update(correo);
            var returned = await _context.SaveChangesAsync();
            return returned > 0 ? true : false;
        }

        public async Task<List<ContactoCorreo>> BuscarCorreosPorIdContacto(long IdContacto)
        {
            return await _context.ContactoCorreo.Where(x => x.IdContacto == IdContacto).ToListAsync();
        }
    }
}
