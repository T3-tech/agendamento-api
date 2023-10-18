using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using agendamento_api.Data;
using agendamento_api.Models;
using agendamento_api.Dtos;
using agendamento_api.DtoResponse;

namespace agendamento_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicosController : ControllerBase
    {
        private readonly AgendamentoContext _context;

        public ServicosController(AgendamentoContext context)
        {
            _context = context;
        }

        // GET: api/Servicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicoReponse>>> GetServicos()
        {
          if (_context.Servicos == null)
          {
              return NotFound();
          }
            List<ServicoReponse> servicoReponses = new List<ServicoReponse>();
            List<Servico> list = await _context.Servicos.ToListAsync();
            foreach (var item in list)
            {
                var nomeProfissional = await _context.Profissionais.FindAsync(item.ProfissionalId);
                ServicoReponse servicoReponse = new ServicoReponse(item.Id, item.Nome, item.Valor, nomeProfissional.Nome);
                servicoReponses.Add(servicoReponse);


            }
            return servicoReponses;
        }

        // GET: api/Servicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servico>> GetServico(int id)
        {
          if (_context.Servicos == null)
          {
              return NotFound();
          }
            var servico = await _context.Servicos.FindAsync(id);

            if (servico == null)
            {
                return NotFound();
            }

            return servico;
        }

        // PUT: api/Servicos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServico(int id, Servico servico)
        {
            if (id != servico.Id)
            {
                return BadRequest();
            }

            _context.Entry(servico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicoExists(id))
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

        // POST: api/Servicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostServico(ServicoDto servicoDto)
        {
          if (_context.Servicos == null)
          {
              return Problem("Entity set 'AgendamentoContext.Servicos'  is null.");
          }
            var profissional = await _context.Profissionais.FindAsync(servicoDto.ProfissionalId);

            

            

            if (profissional != null)
            {
                Servico servico = new Servico(servicoDto.Nome, servicoDto.Valor, servicoDto.ProfissionalId);
                servico.Profissional = profissional;
                _context.Servicos.Add(servico);
                await _context.SaveChangesAsync();

                ServicoReponse servicoResponse = new ServicoReponse(servico.Id, servico.Nome, servico.Valor, servico.Profissional.Nome);

                return Ok(servicoResponse);
            }
            

            return BadRequest();
        }

        // DELETE: api/Servicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServico(int id)
        {
            if (_context.Servicos == null)
            {
                return NotFound();
            }
            var servico = await _context.Servicos.FindAsync(id);
            if (servico == null)
            {
                return NotFound();
            }

            _context.Servicos.Remove(servico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicoExists(int id)
        {
            return (_context.Servicos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
