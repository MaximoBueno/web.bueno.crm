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

        public async Task<Contacto> BuscarContactoPorIdContactoIdGestor(long IdContacto, long IdGestor)
        {
            return await _context.Contacto.Where(x => x.Id == IdContacto && x.IdGestor == IdGestor).FirstOrDefaultAsync();
        }

        public async Task<long> CantidadContactoPorIdGestor(long IdGestor)
        {
            return await _context.Contacto.Where(x => x.IdGestor == IdGestor).CountAsync();
        }

        public async Task<List<Contacto>> ListarContactoPorIdGestor(long IdGestor, int page, int limit)
        {
            if (page == 0)
                page = 1;

            if (limit == 0)
                limit = 20;

            var skip = (page - 1) * limit;

            var searched = _context.Contacto.Skip(skip).Take(limit);

            return await searched.ToListAsync();

        }
    }
}
