using System;
using System.Collections.Generic;

namespace AdminTurismoERP;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string? Email { get; set; }

    public string Token { get; set; } = null!;

    public DateTime Expiracion { get; set; }

    public int? RolId { get; set; }

    public virtual RolesUsuario? Rol { get; set; }
}
