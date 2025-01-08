using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.bueno.crm.domain.sql;

public class ContactoResumen
{
    public long Id { get; set; }

    public long? IdContacto { get; set; }

    public int? IdGestor { get; set; }

    public int? IdGestorAsignado { get; set; }

    public long? IdCampana { get; set; }

    public long? IdProducto { get; set; }

    public int? IdMedio { get; set; }

    public int? IdEstado { get; set; }

    public int? IdResultado { get; set; }

    public decimal? Precio { get; set; }

    public int? Cantidad { get; set; }

    public DateTime? FechaAtencion { get; set; }

    public long? UsuarioCreacion { get; set; }

    public long? UsuarioModificacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    [ForeignKey("IdContacto")]
    public virtual Contacto? Contactos { get; set; }
}
