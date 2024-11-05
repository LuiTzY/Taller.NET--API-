using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller.Domain.entities;

namespace TallerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesTrabajoesController : ControllerBase
    {
        private readonly TallerBdContext _context;

        public OrdenesTrabajoesController(TallerBdContext context)
        {
            _context = context;
        }

        // GET: api/OrdenesTrabajoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenesTrabajo>>> GetOrdenesTrabajos()
        {
            return await _context.OrdenesTrabajos.ToListAsync();
        }

        // GET: api/OrdenesTrabajoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenesTrabajo>> GetOrdenesTrabajo(int id)
        {
            var ordenesTrabajo = await _context.OrdenesTrabajos.FindAsync(id);

            if (ordenesTrabajo == null)
            {
                return NotFound();
            }

            return ordenesTrabajo;
        }

        // PUT: api/OrdenesTrabajoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenesTrabajo(int id, OrdenesTrabajo ordenesTrabajo)
        {
            if (id != ordenesTrabajo.OrdenId)
            {
                return BadRequest();
            }

            _context.Entry(ordenesTrabajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenesTrabajoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OrdenesTrabajoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenesTrabajo>> PostOrdenesTrabajo(OrdenesTrabajo ordenesTrabajo)
        {
            _context.OrdenesTrabajos.Add(ordenesTrabajo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenesTrabajo", new { id = ordenesTrabajo.OrdenId }, ordenesTrabajo);
        }

        // DELETE: api/OrdenesTrabajoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenesTrabajo(int id)
        {
            var ordenesTrabajo = await _context.OrdenesTrabajos.FindAsync(id);
            if (ordenesTrabajo == null)
            {
                return NotFound();
            }

            _context.OrdenesTrabajos.Remove(ordenesTrabajo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenesTrabajoExists(int id)
        {
            return _context.OrdenesTrabajos.Any(e => e.OrdenId == id);
        }
    }
}
