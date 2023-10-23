using System;
using System.Collections.Generic;

namespace AdminTurismoERP;

public partial class Capacidad
{
    public int CapacidadId { get; set; }

    public int CapacidadTour { get; set; }

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
