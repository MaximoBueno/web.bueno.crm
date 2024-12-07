using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.bueno.crm.domain.sql;

namespace web.bueno.crm.aplication.Interface
{
    public interface IUsuarioRepository
    {
        ValueTask<Usuario> Login(string correo, string clave);

    }
}
