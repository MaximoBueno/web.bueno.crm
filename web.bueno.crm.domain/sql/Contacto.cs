using System;
using System.Collections.Generic;

namespace web.bueno.crm.domain.sql;

public class Contacto
{
    public long Id { get; set; }

    public int? IdGestor { get; set; }

    public int? IdGestorAsignado { get; set; }

    public string? Nombres { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public int? IdTipoDocumento { get; set; }

    public string? NumeroDocumento { get; set; }

    public long? UsuarioCreacion { get; set; }

    public long? UsuarioModificacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<ContactoAtencion>? ContactoAtenciones { get; set; }

    public virtual ICollection<ContactoCorreo>? ContactoCorreos { get; set; }

    public virtual ICollection<ContactoDireccion>? ContactoDirecciones { get; set; } 

    public virtual ICollection<ContactoResumen>? ContactoResumenes { get; set; }

    public virtual ICollection<ContactoTelefono>? ContactoTelefonos { get; set; }
}
