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
    public class EmpleadoRepository:IEmpleadoRepository
    {
        private readonly TallerVehiculosContext _context;
        public EmpleadoRepository(TallerVehiculosContext context) {
            _context = context;
        }


        //Metodo para listar todos los empelados
        public async Task<IEnumerable<Empleado>> GetEmpleadosAsync()
        {

            return await _context.Empleados.ToListAsync();

        }
        //Metodo para listar un ciente
        public async Task<Empleado> GetEmpleadoAsync(int id)
        {
            return await _context.Empleados.FindAsync(id);

        }

        //Metodo para agregar un cliente
        public async Task addEmpleadotAsync(Empleado empleado)
        {
            await _context.Empleados.AddAsync(empleado);
            await _context.SaveChangesAsync();
        }

        //Metodo para actualizar un cliente
        public async Task<bool> UpdateEmpleadoAsync(int id, Empleado empleado)
        {
            // Buscar el cliente existente en la base de datos
            var existingEmp = await _context.Empleados.FindAsync(id);

            if (existingEmp == null)
            {
                return false; // Cliente no encontrado
            }

            // Actualizar las propiedades del cliente existente con los valores del cliente entrante
            existingEmp.Nombre = empleado.Nombre;
            existingEmp.Apellido = empleado.Apellido;
            existingEmp.Cargo = empleado.Cargo;
            existingEmp.Telefono = empleado.Telefono;
            existingEmp.Email = empleado.Email;

            // Guardar los cambios
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEmpleadoAsync(int id)
        {
            // Buscar el cliente por ID
            var employee = await _context.Empleados.FindAsync(id);

            // Si el cliente no existe, retorna false
            if (employee == null)
            {
                return false;
            }

            // Eliminar el cliente
            _context.Empleados.Remove(employee);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}
