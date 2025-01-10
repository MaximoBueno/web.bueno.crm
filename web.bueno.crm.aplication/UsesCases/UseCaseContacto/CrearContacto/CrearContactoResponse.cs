using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.bueno.crm.aplication.UsesCases.UseCaseContacto.CrearContacto
{
    public class CrearContactoResponse
    {
        public long Id { get; set; }
        public int? IdGestor { get; set; }

        public int? IdGestorAsignado { get; set; }

        public string Nombres { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public int? IdTipoDocumento { get; set; }

        public string NumeroDocumento { get; set; }
        public DateTime FechaCreacion { get; set; }

        public List<CrearContactoTelefonoResponse>? Telefonos { get; set; }
        public List<CrearContactoCorreoResponse>? Correos { get; set; }
    }

    public class CrearContactoTelefonoResponse
    {
        public long Id { get; set; }
        public int? IdTipoTelefono { get; set; }
        public string NumeroTelefono { get; set; }
    }

    public class CrearContactoCorreoResponse
    {
        public long Id { get; set; }
        public int? IdTipoCorreo { get; set; }
        public string Correo { get; set; }
    }

}
