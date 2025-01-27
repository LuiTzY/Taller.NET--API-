﻿using System;
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
using Taller.infraestructure.Repositories;

namespace TallerAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PiezasController : ControllerBase
    {
        private readonly IPiezaRepository _PiezaRepositoryRepository;

        public PiezasController(IPiezaRepository PiezaRepositoryRepository)
        {
            _PiezaRepositoryRepository = PiezaRepositoryRepository;
        }

        // GET: api/Piezas
        [HttpGet]
        public async Task<IEnumerable<Pieza>> GetPiezas()
        {
            return await _PiezaRepositoryRepository.GetAllPiezasAsync();
        }

        // GET: api/Piezas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pieza>> GetPieza(int id)
        {
            var pieza = await _PiezaRepositoryRepository.GetPiezaAsync(id);

            if (pieza == null)
            {
                return NotFound();
            }

            return pieza;
        }

        // PUT: api/Piezas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPieza(int id, Pieza pieza)
        {
            try
            {
                var isUpdated = await _PiezaRepositoryRepository.UpdatPiezaAsync(id, pieza);

                if (!isUpdated)
                {
                    return NotFound(new { Message = $"La pieza con ID {id} no fue encontrado." });
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Manejar errores inesperados
                return StatusCode(500, new { Message = $"Error interno: {ex.Message}" });
            }
        }

        // POST: api/Piezas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pieza>> PostPieza(Pieza pieza)
        {
            try
            {
                // Agregar la pieza usando el repositorio
                await _PiezaRepositoryRepository.addPiezaAsync(pieza);

                // Retornar la respuesta con la pieza creado
                return CreatedAtAction(
                    nameof(GetPieza), //Metodo que devuelve la pieza 
                    new { id = pieza.PiezaId },
                    pieza
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

        // DELETE: api/Piezas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePieza(int id)
        {
            try
            {
                var isDeleted = await _PiezaRepositoryRepository.DeletePiezaAsync(id);

                if (!isDeleted)
                {
                    return NotFound(new { Message = $"La pieza con ID {id} no fue encontrado." });
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
