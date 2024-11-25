using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller.Domain.Entities;
using  Taller.infraestructure.interfaces;

namespace TallerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenPiezasController : ControllerBase
    {
        private readonly IOrdenPiezaRepository _ordenPiezaRepository;

        public OrdenPiezasController(IOrdenPiezaRepository ordenPiezaRepository)
        {
            _ordenPiezaRepository = ordenPiezaRepository;
        }

        // GET: api/OrdenPiezas
        [HttpGet]
        public async Task<IEnumerable<OrdenPieza>> GetOrdenPiezas()
        {
            return await _ordenPiezaRepository.GetAllOrdenPiezaAsync();
        }

        // GET: api/OrdenPiezas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenPieza>> GetOrdenPieza(int id)
        {
            var ordenPieza = await _ordenPiezaRepository.GetOrdenPiezaAsync(id);

            if (ordenPieza == null)
            {
                return NotFound();
            }

            return ordenPieza;
        }

        // PUT: api/OrdenPiezas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenPieza(int id, OrdenPieza ordenPieza)
        {
            try
            {
                var isUpdated = await _ordenPiezaRepository.UpdateOrdenPiezaAsync(id, ordenPieza);

                if (!isUpdated)
                {
                    return NotFound(new { Message = $"No se pudo encontrar la orden con el ID {id} no fue encontrado." });
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Manejar errores inesperados
                return StatusCode(500, new { Message = $"Error interno: {ex.Message}" });
            }
        }

        // POST: api/OrdenPiezas
        [HttpPost]
        public async Task<ActionResult<OrdenPieza>> PostOrdenPieza(OrdenPieza ordenPieza)
        {
            try
            {
                // Agregar la pieza usando el repositorio
                await _ordenPiezaRepository.addOrdenPiezaAsync(ordenPieza);

                // Retornar la respuesta con la pieza creado
                return CreatedAtAction(
                    nameof(GetOrdenPieza), //Metodo que devuelve la pieza 
                    new { id = ordenPieza.OrdenPiezaId },
                    ordenPieza
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

        // DELETE: api/OrdenPiezas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenPieza(int id)
        {
            try
            {
                var isDeleted = await _ordenPiezaRepository.DeleteOrdenPiezaAsync(id);

                if (!isDeleted)
                {
                    return NotFound(new { Message = $"La orden no se pudo encontrar con ID {id} no fue encontrado." });
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
