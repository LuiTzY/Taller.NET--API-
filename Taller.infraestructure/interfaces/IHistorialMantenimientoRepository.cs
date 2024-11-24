using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Entities;

namespace Taller.infraestructure.interfaces
{
    public interface IHistorialMantenimientoRepository
    {

        Task<IEnumerable<HistorialMantenimiento>> GetHistorialMantenimientosAsync();
        Task<HistorialMantenimiento> GetHistorialMantenimientoAsync(int id);
        Task addHistorialMantenimientoAsync(HistorialMantenimiento mantenimiento);
        Task<bool> UpdateHistorialMantenimientoAsync(int id, HistorialMantenimiento mantenimiento);
        Task<bool> DeleteHistorialMantenimientoAsync(int id);
    }
}
