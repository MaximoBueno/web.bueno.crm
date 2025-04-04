﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using web.bueno.crm.aplication.Abstractions;
using web.bueno.crm.domain.sql;
using web.bueno.crm.infraestructure.Contexts;

namespace web.bueno.crm.infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly CrmLiaContext _context;

        public UsuarioRepository(CrmLiaContext context) {
            _context = context;
        }

        public async ValueTask<Usuario> Login(string correo, string clave)
        {
            return await _context.Usuario.Where(x => x.Correo == correo && x.Clave == clave).FirstOrDefaultAsync();
        }

        public async Task<Usuario> ObtenerUsuarioPorId(long Id)
        {
            return await _context.Usuario.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
    }
}
