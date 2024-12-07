using System;
using System.Collections.Generic;

namespace web.bueno.crm.sql.Models;

public partial class Campana
{
    public long Id { get; set; }

    public string? NombreCampana { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public bool? EsActivo { get; set; }

    public long? UsuarioCreacion { get; set; }

    public long? UsuarioModificacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<CampanaGestor> CampanaGestors { get; set; } = new List<CampanaGestor>();

    public virtual ICollection<CampanaProducto> CampanaProductos { get; set; } = new List<CampanaProducto>();
}
