using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Entities;

namespace Taller.infraestructure.interfaces
{
    public interface IPiezaRepository
    {

        Task<IEnumerable<Pieza>> GetAllPiezasAsync();
        Task<Pieza> GetPiezaAsync(int id);
        Task addPiezaAsync(Pieza pieza);
        Task<bool> UpdatPiezaAsync(int id, Pieza pieza);
        Task<bool> DeletePiezaAsync(int id);

    }
}
