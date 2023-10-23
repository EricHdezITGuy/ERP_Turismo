using System;
using System.Collections.Generic;

namespace AdminTurismoERP;

public partial class Descuento
{
    public int DescuentoId { get; set; }

    public string NombreDescuento { get; set; } = null!;

    public decimal CantidadDescuento { get; set; }

    public string Codigo { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
