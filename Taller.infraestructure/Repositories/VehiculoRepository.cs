using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Entities;
using Taller.infraestructure.interfaces;

namespace Taller.infraestructure.Repositories
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly TallerVehiculosContext _context;

        public VehiculoRepository(TallerVehiculosContext context)
        {

            //inyectamos las dependencias del db context
            _context = context;
        }


        //Implementamos los metodos del repositorio

        //Metodo para listar todos los Vehiculo
        public async Task<IEnumerable<Vehiculo>> GetAllVehiculosAsync()
        {

            return await _context.Vehiculos.ToListAsync();

        }
        //Metodo para listar un Vehiculo
        public async Task<Vehiculo> GetVehiculoAsync(int id)
        {
            return await _context.Vehiculos.FindAsync(id);

        }

        //Metodo para agregar un Vehiculo
        public async Task addVehiculotAsync(Vehiculo vehiculo)
        {
            await _context.Vehiculos.AddAsync(vehiculo);
            await _context.SaveChangesAsync();
        }

        //Metodo para actualizar un Vehiculo
        public async Task<bool> UpdateVehiculoAsync(int id, Vehiculo vehiculo)
        {
            // Buscar el cliente existente en la base de datos
            var existingVehiculo = await _context.Vehiculos.FindAsync(id);

            if (existingVehiculo == null)
            {
                return false; // vehiculo no encontrado
            }

            // Actualizar las propiedades del vehiculo existente con los valores del vehiculo entrante
            existingVehiculo.ClienteId = vehiculo.ClienteId;
            existingVehiculo.Marca = vehiculo.Marca;
            existingVehiculo.Modelo = vehiculo.Modelo;
            existingVehiculo.Año = vehiculo.Año; 
            existingVehiculo.Placa = vehiculo.Placa;
            existingVehiculo.Color = vehiculo.Color;

            // Guardar los cambios
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVehiculoAsync(int id)
        {
            // Buscar el vehiculo por ID
            var vehiculo = await _context.Vehiculos.FindAsync(id);

            // Si el vehiculo no existe, retorna false
            if (vehiculo == null)
            {
                return false;
            }

            // Eliminar el vehiculo
            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync();

            return true;
        }

        


    }
}
