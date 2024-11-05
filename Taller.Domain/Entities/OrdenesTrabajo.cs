using System;
using System.Collections.Generic;

namespace Taller.Domain.entities;

public partial class OrdenesTrabajo
{
    public int OrdenId { get; set; }

    public int? VehiculoId { get; set; }

    public int? EmpleadoId { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }

    public decimal? Costo { get; set; }

    public virtual Empleado? Empleado { get; set; }

    public virtual ICollection<OrdenesPieza> OrdenesPiezas { get; set; } = new List<OrdenesPieza>();

    public virtual Vehiculo? Vehiculo { get; set; }
}
