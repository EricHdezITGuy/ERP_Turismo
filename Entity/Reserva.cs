using System;
using System.Collections.Generic;

namespace AdminTurismoERP;

public partial class Reserva
{
    public int ReservaId { get; set; }

    public int ClienteId { get; set; }

    public int TourId { get; set; }

    public int NumeroPersonas { get; set; }

    public bool Pagado { get; set; }

    public int? DescuentoId { get; set; }

    public int? EstadoId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Descuento? Descuento { get; set; }

    public virtual EstadosReserva? Estado { get; set; }

    public virtual Tour Tour { get; set; } = null!;
}
