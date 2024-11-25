using System;
using System.Collections.Generic;

namespace Taller.Domain.Entities;

public partial class Vehiculo
{
    public int VehiculoId { get; set; }

    public int? ClienteId { get; set; }

    public string? Marca { get; set; }

    public string? Modelo { get; set; }

    public int? Año { get; set; }

    public string? Placa { get; set; }

    public string? Color { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<HistorialMantenimiento> HistorialMantenimientos { get; set; } = new List<HistorialMantenimiento>();

    public virtual ICollection<OrdenesTrabajo> OrdenesTrabajos { get; set; } = new List<OrdenesTrabajo>();
}
