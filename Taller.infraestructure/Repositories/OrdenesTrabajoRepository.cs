using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Entities;
using Taller.infraestructure.interfaces;
using Taller.infraestructure.Context;

namespace Taller.infraestructure.Repositories
{
    public class OrdenesTrabajoRepository : IOrdenesTrabajoRepository
    {
        private readonly TallerVehiculosContext _context;

        public OrdenesTrabajoRepository(TallerVehiculosContext context)
        {

            //inyectamos las dependencias del db context
            _context = context;
        }


        //Implementamos los metodos del repositorio

        //Metodo para listar todos los orden
        public async Task<IEnumerable<OrdenesTrabajo>> GetAllOrdenesdTrabajoAsync()
        {

            return await _context.OrdenesTrabajos.ToListAsync();

        }
        //Metodo para listar un orden
        public async Task<OrdenesTrabajo> GetOrdenTrabajoAsync(int id)
        {
            return await _context.OrdenesTrabajos.FindAsync(id);

        }

        //Metodo para agregar un orden
        public async Task addOrdenTrabajoAsync(OrdenesTrabajo orden)
        {
            await _context.OrdenesTrabajos.AddAsync(orden);
            await _context.SaveChangesAsync();
        }

        //Metodo para actualizar un orden
        public async Task<bool> UpdateOrdenTrabajoAsync(int id, OrdenesTrabajo orden)
        {
            // Buscar el cliente existente en la base de datos
            var existingOrder = await _context.OrdenesTrabajos.FindAsync(id);

            if (existingOrder == null)
            {
                return false; // vehiculo no encontrado
            }

            // Actualizar las propiedades del Order existente con los valores del Order entrante
            existingOrder.VehiculoId = orden.VehiculoId;
            existingOrder.EmpleadoId =  orden.EmpleadoId;
            existingOrder.FechaEntrada = orden.FechaEntrada;
            existingOrder.FechaSalida   = orden.FechaSalida;
            existingOrder.Descripcion = orden.Descripcion;
            existingOrder.TotalCosto = orden.TotalCosto;
            existingOrder.Estado =  orden.Estado;

            // Guardar los cambios
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrdenTrabajoAsync(int id)
        {
            // Buscar el orden por ID
            var orden = await _context.OrdenesTrabajos.FindAsync(id);

            // Si el vehiculo no existe, retorna false
            if (orden == orden)
            {
                return false;
            }

            // Eliminar la orden
            _context.OrdenesTrabajos.Remove(orden);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}
