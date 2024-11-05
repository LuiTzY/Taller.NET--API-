using System;
using System.Collections.Generic;

namespace Taller.Domain.entities;

public partial class Vehiculo
{
    public int VehiculoId { get; set; }

    public int? ClienteId { get; set; }

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public int? Año { get; set; }

    public string Placa { get; set; } = null!;

    public string NumeroSerie { get; set; } = null!;

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<OrdenesTrabajo> OrdenesTrabajos { get; set; } = new List<OrdenesTrabajo>();
}
