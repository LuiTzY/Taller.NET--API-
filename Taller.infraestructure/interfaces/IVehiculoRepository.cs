using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Entities;

namespace Taller.infraestructure.interfaces
{
    public interface IVehiculoRepository
    {
        Task<IEnumerable<Vehiculo>> GetAllVehiculosAsync();
        Task<Vehiculo> GetVehiculoAsync(int id);
        Task addVehiculotAsync(Vehiculo vehiculo);
        Task<bool> UpdateVehiculoAsync(int id, Vehiculo vehiculo);
        Task<bool> DeleteVehiculoAsync(int id);

    }
}
