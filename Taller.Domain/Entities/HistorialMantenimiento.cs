using System;
using System.Collections.Generic;

namespace Taller.Domain.Entities;

public partial class HistorialMantenimiento
{
    public int HistorialId { get; set; }

    public int? VehiculoId { get; set; }

    public int? OrdenId { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public virtual OrdenesTrabajo? Orden { get; set; }

    public virtual Vehiculo? Vehiculo { get; set; }
}
