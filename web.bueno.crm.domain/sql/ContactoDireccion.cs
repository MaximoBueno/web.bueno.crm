using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.bueno.crm.domain.sql;

public class ContactoDireccion
{
    public long Id { get; set; }

    public long? IdContacto { get; set; }

    public int? IdProvincia { get; set; }

    public int? IdDepartamento { get; set; }

    public int? IdDistrito { get; set; }

    public string? Ciudad { get; set; }

    public string? Direccion { get; set; }

    public string? Referencia { get; set; }

    public bool? EsPrincipal { get; set; }

    public long? UsuarioCreacion { get; set; }

    public long? UsuarioModificacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    [ForeignKey("IdContacto")]
    public virtual Contacto? Contactos { get; set; }
}
