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
    public  class PiezaRepository : IPiezaRepository
    {

        private readonly TallerVehiculosContext _context;

        public PiezaRepository(TallerVehiculosContext context)
        {

            //inyectamos las dependencias del db context
            _context = context;
        }


        //Implementamos los metodos del repositorio

        //Metodo para listar todos los Pieza
        public async Task<IEnumerable<Pieza>> GetAllPiezasAsync()
        {

            return await _context.Piezas.ToListAsync();

        }
        //Metodo para listar un Pieza
        public async Task<Pieza> GetPiezaAsync(int id)
        {
            return await _context.Piezas.FindAsync(id);

        }

        //Metodo para agregar un Pieza
        public async Task addPiezaAsync(Pieza pieza)
        {
            await _context.Piezas.AddAsync(pieza);
            await _context.SaveChangesAsync();
        }

        //Metodo para actualizar un cliente
        public async Task<bool> UpdatPiezaAsync(int id, Pieza pieza)
        {
            // Buscar el pieza existente en la base de datos
            var existingPieza = await _context.Piezas.FindAsync(id);

            if (existingPieza == null)
            {
                return false; // Cliente no encontrado
            }

            // Actualizar las propiedades de la pieza existente con los valores de la pieza entrante
            existingPieza.Nombre = pieza.Nombre;
            existingPieza.Descripcion= pieza.Descripcion;
            existingPieza.Precio = pieza.Precio;

            // Guardar los cambios
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePiezaAsync(int id)
        {
            // Buscar por el ID de la pieza
            var pieza = await _context.Piezas.FindAsync(id);

            // Si la pieza no existe, retorna false
            if (pieza == null)
            {
                return false;
            }

            // Eliminar la pieza
            _context.Piezas.Remove(pieza);
            await _context.SaveChangesAsync();

            return true;
        }

        

    }
}
