using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Entities;

namespace Taller.infraestructure.Models
{
    internal class Cliente
    {

        public int ClienteId { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Email { get; set; } = null!;  

        //public virtual List<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
    }
}
