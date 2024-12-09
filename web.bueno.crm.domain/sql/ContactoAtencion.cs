using System;
using System.Collections.Generic;

namespace web.bueno.crm.domain.sql;

public class ContactoAtencion
{
    public long Id { get; set; }

    public long? IdContacto { get; set; }

    public int? IdGestor { get; set; }

    public int? IdGestorAsignado { get; set; }

    public int? IdCampana { get; set; }

    public long? IdProducto { get; set; }

    public int? IdMedio { get; set; }

    public int? IdEstado { get; set; }

    public int? IdResultado { get; set; }

    public int? Cantidad { get; set; }

    public bool? AceptaSerContactado { get; set; }

    public string? Observacion { get; set; }

    public DateTime? FechaAtencion { get; set; }

    public long? UsuarioCreacion { get; set; }

    public long? UsuarioModificacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Contacto? IdContactoNavigation { get; set; }
}
