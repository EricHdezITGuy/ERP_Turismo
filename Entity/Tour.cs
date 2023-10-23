using System;
using System.Collections.Generic;

namespace AdminTurismoERP;

public partial class Tour
{
    public int TourId { get; set; }

    public string NombreTour { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public decimal Costo { get; set; }

    public int CapacidadMaxima { get; set; }

    public int? GuiaId { get; set; }

    public int? CapacidadId { get; set; }

    public virtual Capacidad? Capacidad { get; set; }

    public virtual Guia? Guia { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
