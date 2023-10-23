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
    public class StatusController : ControllerBase
    {
        private readonly AgendamentoContext _context;

        public StatusController(AgendamentoContext context)
        {
            _context = context;
        }

        // GET: api/Status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusResponse>>> GetStatus()
        {
            if (_context.Status == null)
            {
                return NotFound();
            }
            var status = await _context.Status.ToListAsync();
            List<StatusResponse> listaStatusReponse = new List<StatusResponse>();
            foreach (var item in status)
            {
                StatusResponse statusReponse = new StatusResponse(item.Id, item.Nome);
                listaStatusReponse.Add(statusReponse);
            }

            return listaStatusReponse.OrderBy(s => s.Id).ToList();
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusResponse>> GetStatus(int id)
        {
            if (_context.Status == null)
            {
                return NotFound();
            }
            var status = await _context.Status.FindAsync(id);

            StatusResponse statusResponse = new StatusResponse(status.Id, status.Nome);

            if (status == null)
            {
                return NotFound();
            }

            return statusResponse;
        }

        // PUT: api/Status/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(int id, StatusDto statusDto)
        {

            var status = await _context.Status.FindAsync(id);

            status.Nome = statusDto.Nome;


            _context.Entry(status).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusExists(id))
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

        // POST: api/Status
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostStatus(StatusDto statusDto)
        {
            if (_context.Status == null)
            {
                return Problem("Entity set 'AgendamentoContext.Status'  is null.");
            }

            Status status = new Status(statusDto.Nome);
            _context.Status.Add(status);
            await _context.SaveChangesAsync();

            StatusResponse statusResponse = new StatusResponse(status.Id, status.Nome);
            return Ok(statusResponse);
        }

        // DELETE: api/Status/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            if (_context.Status == null)
            {
                return NotFound();
            }
            var status = await _context.Status.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }

            _context.Status.Remove(status);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusExists(int id)
        {
            return (_context.Status?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
