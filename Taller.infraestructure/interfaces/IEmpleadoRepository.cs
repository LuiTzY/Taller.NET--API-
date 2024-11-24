using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Entities;

namespace Taller.infraestructure.interfaces
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> GetEmpleadosAsync();
        Task<Empleado> GetEmpleadoAsync(int id);
        Task addEmpleadotAsync(Empleado empleado);
        Task<bool> UpdateEmpleadoAsync(int id, Empleado empleado);
        Task<bool> DeleteEmpleadoAsync(int id);


    }
}
