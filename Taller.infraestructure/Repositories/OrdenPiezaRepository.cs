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
    public class OrdenPiezaRepository : IOrdenPiezaRepository
    {
        private readonly TallerVehiculosContext _context;

        public OrdenPiezaRepository(TallerVehiculosContext context)
        {

            //inyectamos las dependencias del db context
            _context = context;
        }


        //Implementamos los metodos del repositorio

        //Metodo para listar todos las ordenes de Piezas
        public async Task<IEnumerable<OrdenPieza>> GetAllOrdenPiezaAsync()
        {

            return await _context.OrdenPiezas.ToListAsync();

        }
        //Metodo para listar un Piez
        public async Task<OrdenPieza> GetOrdenPiezaAsync(int id)
        {
            return await _context.OrdenPiezas.FindAsync(id);

        }

        //Metodo para agregar un Pieza
        public async Task addOrdenPiezaAsync(OrdenPieza ordenPieza)
        {
            await _context.OrdenPiezas.AddAsync(ordenPieza);
            await _context.SaveChangesAsync();
        }

        //Metodo para actualizar un cliente
        public async Task<bool> UpdateOrdenPiezaAsync(int id, OrdenPieza ordenPieza)
        {
            // Buscar el cliente existente en la base de datos
            var existingOrder = await _context.OrdenPiezas.FindAsync(id);

            if (existingOrder == null)
            {
                return false; // Cliente no encontrado
            }

            // Actualizar las propiedades del cliente existente con los valores del cliente entrante
            existingOrder.OrdenId = ordenPieza.OrdenId;
            existingOrder.PiezaId= ordenPieza.PiezaId;
            existingOrder.Cantidad= ordenPieza.Cantidad;
            existingOrder.Costo = ordenPieza.Costo;
            existingOrder.FechaUso = ordenPieza.FechaUso;

            // Guardar los cambios
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrdenPiezaAsync(int id)
        {
            // Buscar el cliente por ID
            var ordenPieza = await _context.OrdenPiezas.FindAsync(id);

            // Si el cliente no existe, retorna false
            if (ordenPieza == null)
            {
                return false;
            }

            // Eliminar la orden de la pieza
            _context.OrdenPiezas.Remove(ordenPieza);
            await _context.SaveChangesAsync();

            return true;
        }

      
    }
}
