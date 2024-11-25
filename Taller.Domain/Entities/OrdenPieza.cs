using System;
using System.Collections.Generic;

namespace Taller.Domain.Entities;

public partial class OrdenPieza
{
    public int OrdenPiezaId { get; set; }

    public int OrdenId { get; set; }

    public int PiezaId { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Costo { get; set; }

    public DateTime? FechaUso { get; set; }

    public virtual OrdenesTrabajo Orden { get; set; } = null!;

    public virtual Pieza Pieza { get; set; } = null!;
}
