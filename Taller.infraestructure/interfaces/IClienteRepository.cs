using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Entities;

namespace Taller.infraestructure.interfaces
{
    public  interface IClienteRepository
    {


        Task<IEnumerable<Cliente>> GetAllClientsAsync();
        Task<Cliente> GetClientAsync(int id);
        Task addClientAsync(Cliente client);
        Task <bool> UpdateClientAsync (int id,Cliente client);
        Task<Boolean> DeleteClientAsync(int id);

        Task<IEnumerable<Cliente>> getClientVehicles(int id);
    }
}


