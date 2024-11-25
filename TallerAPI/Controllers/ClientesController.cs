using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Taller.Domain.Entities;
using Taller.infraestructure.interfaces;
using Taller.infraestructure.Repositories;

namespace TallerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _ClientRepository;

        public ClientesController(IClienteRepository ClientRepo)
        {
            _ClientRepository = ClientRepo;
        }

        // GET: api/Clientes
        [HttpGet("clients/")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClients()
        {
            var clients = await _ClientRepository.GetAllClientsAsync();

            return Ok(clients);
        }


        // GET: api/Clientes/5
        [HttpGet("client/{id}")]
        public async Task<ActionResult<Cliente>> GetClient(int id)
        {
            var client = await _ClientRepository.GetClientAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }


        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("client")]
        public async Task<ActionResult<Cliente>> CreateClient(Cliente client)
        {
            try
            {
                // Agregar el cliente usando el repositorio
                await _ClientRepository.addClientAsync(client);

                // Retornar la respuesta con el cliente creado
                return CreatedAtAction(
                    nameof(GetClient), //Metodo que devuelve un cliente
                    new { id = client.ClienteId }, 
                    client 
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


        [HttpPut("client/{id}")]
        public async Task<IActionResult> UpdateClient(int id, Cliente client)
        {
            try
            {
                var isUpdated = await _ClientRepository.UpdateClientAsync(id, client);

                if (!isUpdated)
                {
                    return NotFound(new { Message = $"El cliente con ID {id} no fue encontrado." });
                }

                return NoContent(); 
            }
            catch (Exception ex)
            {
                // Manejar errores inesperados
                return StatusCode(500, new { Message = $"Error interno: {ex.Message}" });
            }
        }


        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                var isDeleted = await _ClientRepository.DeleteClientAsync(id);

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
