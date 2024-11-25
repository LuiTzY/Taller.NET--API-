using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller.Domain.Entities;
using Taller.infraestructure;
using Taller.infraestructure.interfaces;
namespace TallerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoRepository _VehiculoRepository;

        public VehiculosController(IVehiculoRepository VehiculoRepository)
        {
            _VehiculoRepository = VehiculoRepository;
        }

        // GET: api/Vehiculoes
        [HttpGet]
        public async Task<IEnumerable<Vehiculo>> GetVehiculos()
        {
            return await _VehiculoRepository.GetAllVehiculosAsync();
        }

        // GET: api/Vehiculoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculo>> GetVehiculo(int id)
        {
            var vehiculo = await _VehiculoRepository.GetVehiculoAsync(id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return vehiculo;
        }

        // PUT: api/Vehiculoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehiculo(int id, Vehiculo vehiculo)
        {
            try
            {
                var isUpdated = await _VehiculoRepository.UpdateVehiculoAsync(id, vehiculo);

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

        // POST: api/Vehiculoes
        [HttpPost]
        public async Task<ActionResult<Vehiculo>> PostVehiculo(Vehiculo vehiculo)
        {
            try
            {
                // Agregar el cliente usando el repositorio
                await _VehiculoRepository.addVehiculotAsync(vehiculo);

                // Retornar la respuesta con el empleado creado
                return CreatedAtAction(
                    nameof(GetVehiculo), //Metodo que devuelve un cliente
                    new { id = vehiculo.VehiculoId },
                    vehiculo
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

        // DELETE: api/Vehiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehiculo(int id)
        {

            try
            {
                var isDeleted = await _VehiculoRepository.DeleteVehiculoAsync(id);

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
