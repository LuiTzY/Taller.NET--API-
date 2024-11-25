using System;
using System.Collections.Generic;

namespace Taller.Domain.Entities;

public partial class Pieza
{
    public int PiezaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public virtual ICollection<OrdenPieza> OrdenPiezas { get; set; } = new List<OrdenPieza>();
}
