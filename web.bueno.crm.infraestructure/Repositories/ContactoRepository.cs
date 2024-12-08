using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.bueno.crm.aplication.Abstractions;
using web.bueno.crm.domain.sql;
using web.bueno.crm.infraestructure.Contexts;

namespace web.bueno.crm.infraestructure.Repositories
{
    public class ContactoRepository : IContactoRepository
    {
        private readonly CrmLiaContext _context;

        public ContactoRepository(CrmLiaContext context)
        {
            _context = context;
        }

        public async Task<Contacto> CrearContacto(Contacto contacto)
        {
            await _context.Contacto.AddAsync(contacto);
            await _context.SaveChangesAsync();
            return contacto;
        }

        public async Task<bool> EditarContacto(Contacto contacto)
        {
            _context.Contacto.Update(contacto);
            var returned = await _context.SaveChangesAsync();
            return returned > 0 ? true : false;
        }
    }
}
