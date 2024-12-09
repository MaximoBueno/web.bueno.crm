using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.bueno.crm.domain.sql;

public class Usuario
{
    public long Id { get; set; }

    public long? IdPersona { get; set; }

    public string? NombreCompleto { get; set; }

    public string Correo { get; set; }

    public string Clave { get; set; }

    public string Roles { get; set; }

    public long? UsuarioCreacion { get; set; }

    public long? UsuarioModificacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Gestor>? Gestores { get; set; } //puede ser o no un gestor

    [ForeignKey("IdPersona")]
    public virtual Persona? Persona { get; set; }
}
