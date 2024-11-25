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
    public class HistorialMantenimientoRepository: IHistorialMantenimientoRepository
    {
        private readonly TallerVehiculosContext _context;

        public HistorialMantenimientoRepository(TallerVehiculosContext context)
        {
            _context = context; 
        }


        //Metodo para listar todos los mantenimiento
        public async Task<IEnumerable<HistorialMantenimiento>> GetHistorialMantenimientosAsync()
        {

            return await _context.HistorialMantenimientos.ToListAsync();

        }
        //Metodo para listar un mantenimiento
        public async Task<HistorialMantenimiento> GetHistorialMantenimientoAsync(int id)
        {
            return await _context.HistorialMantenimientos.FindAsync(id);

        }

        //Metodo para agregar un mantenimiento
        public async Task addHistorialMantenimientoAsync(HistorialMantenimiento mantenimiento)
        {
            await _context.HistorialMantenimientos.AddAsync(mantenimiento);
            await _context.SaveChangesAsync();
        }

        //Metodo para actualizar un mantenimiento
        public async Task<bool> UpdateHistorialMantenimientoAsync(int id, HistorialMantenimiento mantenimiento)
        {
            // Buscar el mantenimiento existente en la base de datos
            var existingMantenimiento = await _context.HistorialMantenimientos.FindAsync(id);

            if (existingMantenimiento == null)
            {
                return false; 
            }

            // Actualizar las propiedades del mantenimiento existente con los valores del mantenimiento entrante
            existingMantenimiento.VehiculoId = existingMantenimiento.VehiculoId;
            existingMantenimiento.OrdenId = mantenimiento.OrdenId;
            existingMantenimiento.Fecha = mantenimiento.Fecha;
            existingMantenimiento.Descripcion = mantenimiento.Descripcion;

            // Guardar los cambios
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteHistorialMantenimientoAsync(int id)
        {
            // Buscar el mantenimiento por ID
            var maintenance = await _context.HistorialMantenimientos.FindAsync(id);

            // Si el mantenimiento no existe, retorna false
            if (maintenance == null)
            {
                return false;
            }

            // Eliminar el mantenimiento
            _context.HistorialMantenimientos.Remove(maintenance);
            await _context.SaveChangesAsync();

            return true;
        }


    

}
}
