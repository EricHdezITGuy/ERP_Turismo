using System;
using System.Collections.Generic;

namespace AdminTurismoERP;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public long? Telefono { get; set; }

    public string? Comentarios { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
