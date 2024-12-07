using System;
using System.Collections.Generic;

namespace web.bueno.crm.domain.sql;

public class ContactoTelefono
{
    public long Id { get; set; }

    public long? IdContacto { get; set; }

    public int? IdTipoTelefono { get; set; }

    public string? NumeroTelefono { get; set; }

    public bool? EsPrincipal { get; set; }

    public long? UsuarioCreacion { get; set; }

    public long? UsuarioModificacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Contacto? IdContactoNavigation { get; set; }
}
