using System;
using System.Collections.Generic;

namespace web.bueno.crm.domain.sql;

public class Campana
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

    public virtual ICollection<CampanaGestor> CampanaGestors { get; set; }

    public virtual ICollection<CampanaProducto> CampanaProductos { get; set; }
}
