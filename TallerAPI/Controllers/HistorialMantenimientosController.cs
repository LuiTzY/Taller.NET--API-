using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Taller.Domain.Entities;
using Taller.infraestructure;
using Taller.infraestructure.interfaces;
using Taller.infraestructure.Repositories;

namespace TallerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HistorialMantenimientosController : ControllerBase
    {
        private readonly IHistorialMantenimientoRepository _HistorialMantenimientoRepository;

        public HistorialMantenimientosController(IHistorialMantenimientoRepository HistorialMantenimientoRepository)
        {
            _HistorialMantenimientoRepository = HistorialMantenimientoRepository;
        }

        // GET: api/HistorialMantenimientos
        [HttpGet]
        public async Task<IEnumerable<HistorialMantenimiento>> GetHistorialMantenimientos()
        {
            return await _HistorialMantenimientoRepository.GetHistorialMantenimientosAsync();
        }

        // GET: api/HistorialMantenimientos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialMantenimiento>> GetHistorialMantenimiento(int id)
        {
            var mantenimiento = await _HistorialMantenimientoRepository.GetHistorialMantenimientoAsync(id);

            if (mantenimiento == null)
            {
                return NotFound();
            }

            return Ok(mantenimiento);
        }

        // PUT: api/HistorialMantenimientos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHistorialMantenimiento(int id, HistorialMantenimiento historialMantenimiento)
        {
            try
            {
                var isUpdated = await _HistorialMantenimientoRepository.UpdateHistorialMantenimientoAsync(id, historialMantenimiento);

                if (!isUpdated)
                {
                    return NotFound(new { Message = $"El mantenimiento con ID {id} no fue encontrado." });
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Manejar errores inesperados
                return StatusCode(500, new { Message = $"Error interno: {ex.Message}" });
            }
        }

        // POST: api/HistorialMantenimientos
        [HttpPost]
        public async Task<ActionResult<HistorialMantenimiento>> CreateHistorialMantenimiento(HistorialMantenimiento mantenimiento)
        {
            try
            {
                // Agregar el cliente usando el repositorio
                await _HistorialMantenimientoRepository.addHistorialMantenimientoAsync(mantenimiento);

                // Retornar la respuesta con el mantenimiento creado
                return CreatedAtAction(
                    nameof(GetHistorialMantenimiento), //Metodo que devuelve un mantenimiento
                    new { id = mantenimiento.HistorialId },
                    mantenimiento
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
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/HistorialMantenimientos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialMantenimiento(int id)
        {
            try
            {
                var isDeleted = await _HistorialMantenimientoRepository.DeleteHistorialMantenimientoAsync(id);

                if (!isDeleted)
                {
                    return NotFound(new { Message = $"El cliente con ID {id} no fue encontrado." });
                }

                return NoContent(); // Eliminación exitosa
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción genérica
                return StatusCode(500, new { Message = $"Error interno: {ex.Message}" });
            }
        }

       
    }
}
