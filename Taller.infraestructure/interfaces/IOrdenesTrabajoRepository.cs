using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Entities;

namespace Taller.infraestructure.interfaces
{
    public interface IOrdenesTrabajoRepository
    {
        Task<IEnumerable<OrdenesTrabajo>> GetAllOrdenesdTrabajoAsync();
        Task<OrdenesTrabajo> GetOrdenTrabajoAsync(int id);
        Task addOrdenTrabajoAsync(OrdenesTrabajo orden);
        Task<bool> UpdateOrdenTrabajoAsync(int id, OrdenesTrabajo orden);
        Task<bool> DeleteOrdenTrabajoAsync(int id);

    }
}
