using System;
using System.Collections.Generic;

namespace web.bueno.crm.sql.Models;

public partial class Contacto
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

    public virtual ICollection<ContactoAtencion> ContactoAtencions { get; set; } = new List<ContactoAtencion>();

    public virtual ICollection<ContactoCorreo> ContactoCorreos { get; set; } = new List<ContactoCorreo>();

    public virtual ICollection<ContactoDireccion> ContactoDireccions { get; set; } = new List<ContactoDireccion>();

    public virtual ICollection<ContactoResuman> ContactoResumen { get; set; } = new List<ContactoResuman>();

    public virtual ICollection<ContactoTelefono> ContactoTelefonos { get; set; } = new List<ContactoTelefono>();
}
