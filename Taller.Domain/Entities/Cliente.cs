using System;
using System.Collections.Generic;

namespace Taller.Domain.entities;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Vehiculo>? Vehiculos { get; set; } = new List<Vehiculo>();
}
