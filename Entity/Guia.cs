using System;
using System.Collections.Generic;

namespace AdminTurismoERP;

public partial class Guia
{
    public int GuiaId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
