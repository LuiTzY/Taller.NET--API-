using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Taller.Domain.Entities;
using Taller.infraestructure.interfaces;
using Taller.infraestructure.Context;

namespace Taller.infraestructure.Repositories
{
    //declaramos el repo que implementara en el constructor el db context
    public class ClienteRepository : IClienteRepository
    {
       private readonly TallerVehiculosContext _context;

       public ClienteRepository(TallerVehiculosContext context) {

            //inyectamos las dependencias del db context
            _context = context;        
        }


        //Implementamos los metodos del repositorio

        //Metodo para listar todos los clientes
        public async Task<IEnumerable<Cliente>> GetAllClientsAsync() { 
            
            return await _context.Clientes.ToListAsync();   

        }
        //Metodo para listar un ciente
        public async Task<Cliente> GetClientAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);

        }

        //Metodo para agregar un cliente
        public async Task addClientAsync(Cliente client)
        {
            await _context.Clientes.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        //Metodo para actualizar un cliente
        public async Task<bool> UpdateClientAsync(int id,Cliente client)
        {
            // Buscar el cliente existente en la base de datos
            var existingClient = await _context.Clientes.FindAsync(id);

            if (existingClient == null)
            {
                return false; // Cliente no encontrado
            }

            // Actualizar las propiedades del cliente existente con los valores del cliente entrante
            existingClient.Nombre = client.Nombre;
            existingClient.Apellido = client.Apellido;
            existingClient.Direccion = client.Direccion;
            existingClient.Telefono = client.Telefono;
            existingClient.Email = client.Email;

            // Guardar los cambios
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            // Buscar el cliente por ID
            var client = await _context.Clientes.FindAsync(id);

            // Si el cliente no existe, retorna false
            if (client == null)
            {
                return false;
            }

            // Eliminar el cliente
            _context.Clientes.Remove(client);
            await _context.SaveChangesAsync();

            return true;
        }

        //Metodo para eliminar un cliente
        public async Task<IEnumerable<Cliente>> getClientVehicles(int id)
        {
            var client = _context.Clientes.FindAsync(id);
            return await _context.Clientes.Include(d => d.Vehiculos).ToListAsync();
        }


    }
}