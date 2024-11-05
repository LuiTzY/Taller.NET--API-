using System;
using System.Collections.Generic;

namespace Taller.Domain.entities;

public partial class Pieza
{
    public int PiezaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int CantidadEnInventario { get; set; }

    public virtual ICollection<OrdenesPieza> OrdenesPiezas { get; set; } = new List<OrdenesPieza>();
}
