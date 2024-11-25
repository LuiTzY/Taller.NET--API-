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
    public class OrdenesTrabajosController : ControllerBase
    {
        private readonly IOrdenesTrabajoRepository _ordenesTrabajoRepository;

        public OrdenesTrabajosController(IOrdenesTrabajoRepository ordenesTrabajoRepository)
        {
            _ordenesTrabajoRepository = ordenesTrabajoRepository;
        }

        // GET: api/OrdenesTrabajos
        [HttpGet]
        public async Task<IEnumerable<OrdenesTrabajo>> GetOrdenesTrabajos()
        {
            return await _ordenesTrabajoRepository.GetAllOrdenesdTrabajoAsync();
        }

        // GET: api/OrdenesTrabajos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenesTrabajo>> GetOrdenesTrabajo(int id)
        {
            var ordenesTrabajo = await _ordenesTrabajoRepository.GetOrdenTrabajoAsync(id);

            if (ordenesTrabajo == null)
            {
                return NotFound();
            }

            return ordenesTrabajo;
        }

        // PUT: api/OrdenesTrabajos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenesTrabajo(int id, OrdenesTrabajo ordenesTrabajo)
        {
            try
            {
                var isUpdated = await _ordenesTrabajoRepository.UpdateOrdenTrabajoAsync(id, ordenesTrabajo);

                if (!isUpdated)
                {
                    return NotFound(new { Message = $"La orden con ID {id} no fue encontrado." });
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Manejar errores inesperados
                return StatusCode(500, new { Message = $"Error interno: {ex.Message}" });
            }
        }

        // POST: api/OrdenesTrabajos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenesTrabajo>> PostOrdenesTrabajo(OrdenesTrabajo ordenesTrabajo)
        {
            try
            {
                // Agregar la orden usando el repositorio
                await _ordenesTrabajoRepository.addOrdenTrabajoAsync(ordenesTrabajo);

                // Retornar la respuesta con la orden creada
                return CreatedAtAction(
                    nameof(GetOrdenesTrabajo), //Metodo que devuelve un cliente
                    new { id = ordenesTrabajo.OrdenId },
                    ordenesTrabajo
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

        // DELETE: api/OrdenesTrabajos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenesTrabajo(int id)
        {
            try
            {
                var isDeleted = await _ordenesTrabajoRepository.DeleteOrdenTrabajoAsync(id);

                if (!isDeleted)
                {
                    return NotFound(new { Message = $"La orden con ID {id} no fue encontrado." });
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
