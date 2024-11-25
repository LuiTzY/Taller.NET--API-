using System;
using System.Collections.Generic;

namespace Taller.Domain.Entities;

public partial class OrdenesTrabajo
{
    public int OrdenId { get; set; }

    public int? VehiculoId { get; set; }

    public int? EmpleadoId { get; set; }

    public DateTime? FechaEntrada { get; set; }

    public DateTime? FechaSalida { get; set; }

    public string? Descripcion { get; set; }

    public string? Estado { get; set; }

    public decimal? TotalCosto { get; set; }

    public virtual Empleado? Empleado { get; set; }

    public virtual ICollection<HistorialMantenimiento> HistorialMantenimientos { get; set; } = new List<HistorialMantenimiento>();

    public virtual ICollection<OrdenPieza> OrdenPiezas { get; set; } = new List<OrdenPieza>();

    public virtual Vehiculo? Vehiculo { get; set; }
}
