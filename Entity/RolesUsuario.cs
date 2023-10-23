using System;
using System.Collections.Generic;

namespace AdminTurismoERP;

public partial class RolesUsuario
{
    public int RolId { get; set; }

    public string NombreRol { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
