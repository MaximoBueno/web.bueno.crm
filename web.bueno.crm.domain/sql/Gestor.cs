using System;
using System.Collections.Generic;

namespace web.bueno.crm.domain.sql;

public class Gestor
{
    public int Id { get; set; }

    public long? IdUsuario { get; set; }

    public int? IdTipoGestor { get; set; }

    public long? UsuarioCreacion { get; set; }

    public long? UsuarioModificacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
