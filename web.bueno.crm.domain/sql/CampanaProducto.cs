using System;
using System.Collections.Generic;

namespace web.bueno.crm.domain.sql;

public class CampanaProducto
{
    public long Id { get; set; }

    public long? IdCampana { get; set; }

    public long? IdProducto { get; set; }

    public bool? EsActivo { get; set; }

    public long? UsuarioCreacion { get; set; }

    public long? UsuarioModificacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Campana? IdCampanaNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
