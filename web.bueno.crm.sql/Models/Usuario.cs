using System;
using System.Collections.Generic;

namespace web.bueno.crm.sql.Models;

public partial class Usuario
{
    public long Id { get; set; }

    public long? IdPersona { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }

    public long? UsuarioCreacion { get; set; }

    public long? UsuarioModificacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Gestor> Gestors { get; set; } = new List<Gestor>();

    public virtual Persona? IdPersonaNavigation { get; set; }
}
