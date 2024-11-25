using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller.Domain.Entities;
using Taller.infraestructure;
using Taller.infraestructure.interfaces;
using Taller.infraestructure.Repositories;

namespace TallerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadosController(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        // GET: api/Empleados
        [HttpGet("employees/")]
        public async Task<IEnumerable<Empleado>> GetEmpleados()
        {
            return await _empleadoRepository.GetEmpleadosAsync();
        }

        // GET: api/Empleados/5
        [HttpGet("employee/{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            var empleado = await _empleadoRepository.GetEmpleadoAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        [HttpPut("employee/{id}")]
        public async Task<IActionResult> UpdateEmpleado(int id, Empleado empleado)
        {
            try
            {
                var isUpdated = await _empleadoRepository.UpdateEmpleadoAsync(id, empleado);

                if (!isUpdated)
                {
                    return NotFound(new { Message = $"El empleado con ID {id} no fue encontrado." });
                }

                return NoContent(); 
            }
            catch (Exception ex)
            {
                // Manejar errores inesperados
                return StatusCode(500, new { Message = $"Error interno: {ex.Message}" });
            }
        }

      
        [HttpPost]
        public async Task<ActionResult<Empleado>> CreateEmpleado(Empleado empleado)
        {
            try
            {
                // Agregar el cliente usando el repositorio
                await _empleadoRepository.addEmpleadotAsync(empleado);

                // Retornar la respuesta con el empleado creado
                return CreatedAtAction(
                    nameof(GetEmpleado), //Metodo que devuelve un cliente
                    new { id = empleado.EmpleadoId},
                    empleado
                );
            }
            //Capturamos errores de la db
            catch (DbException ex)
            {
                // Error específico al interactuar con la base de datos
                return StatusCode(500, $"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Error 
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            try
            {
                var isDeleted = await _empleadoRepository.DeleteEmpleadoAsync(id);

                if (!isDeleted)
                {
                    return NotFound(new { Message = $"El cliente con ID {id} no fue encontrado." });
                }

                return NoContent(); //  exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción 
                return StatusCode(500, new { Message = $"Error interno: {ex.Message}" });
            }
        }

        
    }
}
