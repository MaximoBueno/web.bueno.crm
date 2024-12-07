using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.bueno.crm.aplication.Interface;
using web.bueno.crm.domain.sql;
using web.bueno.crm.infraestructure.Contexts;

namespace web.bueno.crm.infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly CrmliaContext _context;

        public UsuarioRepository(CrmliaContext context) {
            _context = context;
        }

        public async ValueTask<Usuario> Login(string correo, string clave)
        {
            return await _context.Usuarios.Where(x => x.Correo == correo && x.Clave == clave).FirstOrDefaultAsync();
        }
    }
}
