using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using agendamento_api.Data;
using agendamento_api.Models;

namespace agendamento_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionaisController : ControllerBase
    {
        private readonly AgendamentoContext _context;

        public ProfissionaisController(AgendamentoContext context)
        {
            _context = context;
        }

        // GET: api/Profissionais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profissional>>> GetProfissionais()
        {
          if (_context.Profissionais == null)
          {
              return NotFound();
          }
            return await _context.Profissionais.ToListAsync();
        }

        // GET: api/Profissionais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profissional>> GetProfissional(int id)
        {
          if (_context.Profissionais == null)
          {
              return NotFound();
          }
            var profissional = await _context.Profissionais.FindAsync(id);

            if (profissional == null)
            {
                return NotFound();
            }

            return profissional;
        }

        // PUT: api/Profissionais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfissional(int id, Profissional profissional)
        {
            if (id != profissional.Id)
            {
                return BadRequest();
            }

            _context.Entry(profissional).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfissionalExists(id))
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

        // POST: api/Profissionais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profissional>> PostProfissional(Profissional profissional)
        {
          if (_context.Profissionais == null)
          {
              return Problem("Entity set 'AgendamentoContext.Profissionais'  is null.");
          }
            _context.Profissionais.Add(profissional);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfissional", new { id = profissional.Id }, profissional);
        }

        // DELETE: api/Profissionais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfissional(int id)
        {
            if (_context.Profissionais == null)
            {
                return NotFound();
            }
            var profissional = await _context.Profissionais.FindAsync(id);
            if (profissional == null)
            {
                return NotFound();
            }

            _context.Profissionais.Remove(profissional);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfissionalExists(int id)
        {
            return (_context.Profissionais?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
