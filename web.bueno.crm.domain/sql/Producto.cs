using System;
using System.Collections.Generic;

namespace web.bueno.crm.domain.sql;

public class Producto
{
    public long Id { get; set; }

    public string? NombreProducto { get; set; }

    public decimal? Precio { get; set; }

    public int? Cantidad { get; set; }

    public bool? EsActivo { get; set; }

    public long? UsuarioCreacion { get; set; }

    public long? UsuarioModificacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<CampanaProducto> CampanaProductos { get; set; }
}
