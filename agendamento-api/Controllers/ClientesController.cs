using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using agendamento_api.Data;
using agendamento_api.Models;
using agendamento_api.DtosRequest;
using agendamento_api.DtoResponse;

namespace agendamento_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AgendamentoContext _context;

        public ClientesController(AgendamentoContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteResponse>>> GetClientes()
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes.ToListAsync();

            List<ClienteResponse> listaClienteResponse = new List<ClienteResponse>();


            foreach (var item in clientes)
            {
                ClienteResponse clienteResponse = new ClienteResponse(item.Id, item.Nome, item.Telefone, item.Cpf);

                listaClienteResponse.Add(clienteResponse);
            }

            return listaClienteResponse;
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteResponse>> GetCliente(int id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            ClienteResponse clienteResponse = new(cliente.Id, cliente.Nome, cliente.Telefone, cliente.Cpf);

            return clienteResponse;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteDto clienteRequest)
        {


            var cliente = await _context.Clientes.FindAsync(id);

            cliente.Nome = clienteRequest.Nome;
            cliente.Telefone = clienteRequest.Telefone;
            cliente.Cpf = clienteRequest.Cpf;


            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostCliente(ClienteDto clienteDto)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'AgendamentoContext.Clientes'  is null.");
            }

            if (CpfExists(clienteDto.Cpf))
            {
                return BadRequest("CPF já cadastrado.");
            }

            Cliente cliente = new Cliente(clienteDto.Nome, clienteDto.Telefone, clienteDto.Cpf);
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            var clienteResponse = new
            {
                nome = cliente.Nome,
                telefone = cliente.Telefone,
                cpf = cliente.Cpf
            };
            return Ok(clienteResponse);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private bool CpfExists(string cpf)
        {
            return (_context.Clientes?.Any(e => e.Cpf == cpf)).GetValueOrDefault();
        }
    }
}
