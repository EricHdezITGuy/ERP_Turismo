using System;
using System.Collections.Generic;

namespace AdminTurismoERP;

public partial class EstadosReserva
{
    public int EstadoId { get; set; }

    public string NombreEstado { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
