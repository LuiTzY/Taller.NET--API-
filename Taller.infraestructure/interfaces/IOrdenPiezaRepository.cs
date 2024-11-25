using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Entities;

namespace Taller.infraestructure.interfaces
{
    public interface IOrdenPiezaRepository
    {
        Task<IEnumerable<OrdenPieza>> GetAllOrdenPiezaAsync();
        Task<OrdenPieza> GetOrdenPiezaAsync(int id);
        Task addOrdenPiezaAsync(OrdenPieza ordenPieza);
        Task<bool> UpdateOrdenPiezaAsync(int id, OrdenPieza ordenPieza);
        Task<bool> DeleteOrdenPiezaAsync(int id);
    }
}
