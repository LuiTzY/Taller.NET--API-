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
    public class OrdenesPiezasController : ControllerBase
    {
        private readonly TallerBdContext _context;

        public OrdenesPiezasController(TallerBdContext context)
        {
            _context = context;
        }

        // GET: api/OrdenesPiezas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenesPieza>>> GetOrdenesPiezas()
        {
            return await _context.OrdenesPiezas.ToListAsync();
        }

        // GET: api/OrdenesPiezas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenesPieza>> GetOrdenesPieza(int id)
        {
            var ordenesPieza = await _context.OrdenesPiezas.FindAsync(id);

            if (ordenesPieza == null)
            {
                return NotFound();
            }

            return ordenesPieza;
        }

        // PUT: api/OrdenesPiezas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenesPieza(int id, OrdenesPieza ordenesPieza)
        {
            if (id != ordenesPieza.OrdenId)
            {
                return BadRequest();
            }

            _context.Entry(ordenesPieza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenesPiezaExists(id))
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

        // POST: api/OrdenesPiezas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdenesPieza>> PostOrdenesPieza(OrdenesPieza ordenesPieza)
        {
            _context.OrdenesPiezas.Add(ordenesPieza);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrdenesPiezaExists(ordenesPieza.OrdenId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrdenesPieza", new { id = ordenesPieza.OrdenId }, ordenesPieza);
        }

        // DELETE: api/OrdenesPiezas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenesPieza(int id)
        {
            var ordenesPieza = await _context.OrdenesPiezas.FindAsync(id);
            if (ordenesPieza == null)
            {
                return NotFound();
            }

            _context.OrdenesPiezas.Remove(ordenesPieza);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenesPiezaExists(int id)
        {
            return _context.OrdenesPiezas.Any(e => e.OrdenId == id);
        }
    }
}
