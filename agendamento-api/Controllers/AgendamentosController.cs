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
    public class AgendamentosController : ControllerBase
    {
        private readonly AgendamentoContext _context;

        public AgendamentosController(AgendamentoContext context)
        {
            _context = context;
        }

        // GET: api/Agendamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendamentoResponse>>> GetAgendamentos()
        {
          if (_context.Agendamentos == null)
          {
              return NotFound();
          }
            var agendamentos = await _context.Agendamentos.ToListAsync();
            List<AgendamentoResponse> agendamentoResponses = new List<AgendamentoResponse>();
            foreach (var item in agendamentos) 
            {
                var servico = await _context.Servicos.FindAsync(item.ServicoId);

                AgendamentoResponse agendamento = new AgendamentoResponse();
                agendamento.Id = item.Id;
                agendamento.Data = item.Data;
                agendamento.StatusId = item.StatusId;
                agendamento.StatusNome = _context.Status.Where(x => x.Id == item.StatusId).Select(x => x.Nome).FirstOrDefault();
                agendamento.ClienteId = item.ClienteId;
                agendamento.ClienteNome = _context.Clientes.Where(x => x.Id == item.ClienteId).Select(x => x.Nome).FirstOrDefault();
                agendamento.ServicoId = item.ServicoId;
                agendamento.ServicoNome = _context.Servicos.Where(x => x.Id == item.ServicoId).Select(x => x.Nome).FirstOrDefault();
                agendamento.ProfissionalId = servico.ProfissionalId;
                agendamento.ProfissionalNome = _context.Profissionais.Where(x => x.Id == servico.ProfissionalId).Select(x => x.Nome).FirstOrDefault();
                agendamento.Valor = item.Servicos.Valor;
                agendamentoResponses.Add(agendamento);
            }
            return agendamentoResponses.OrderBy(x => x.Id).ToList();
        }

        // GET: api/Agendamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgendamentoResponse>> GetAgendamento(int id)
        {
          if (_context.Agendamentos == null)
          {
              return NotFound();
          }
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }

            var servico = await _context.Servicos.FindAsync(agendamento.ServicoId);

            AgendamentoResponse agendamentoResponse = new AgendamentoResponse();
            agendamentoResponse.Id = agendamento.Id;
            agendamentoResponse.Data = agendamento.Data;
            agendamentoResponse.StatusId = agendamento.StatusId;
            agendamentoResponse.StatusNome = _context.Status.Where(x => x.Id == agendamento.StatusId).Select(x => x.Nome).FirstOrDefault();
            agendamentoResponse.ClienteId = agendamento.ClienteId;
            agendamentoResponse.ClienteNome = _context.Clientes.Where(x => x.Id == agendamento.ClienteId).Select(x => x.Nome).FirstOrDefault();
            agendamentoResponse.ServicoId = agendamento.ServicoId;
            agendamentoResponse.ServicoNome = _context.Servicos.Where(x => x.Id == agendamento.ServicoId).Select(x => x.Nome).FirstOrDefault();
            agendamentoResponse.ProfissionalId = servico.ProfissionalId;
            agendamentoResponse.ProfissionalNome = _context.Profissionais.Where(x => x.Id == servico.ProfissionalId).Select(x => x.Nome).FirstOrDefault();
            agendamentoResponse.Valor = agendamento.Servicos.Valor;

            return agendamentoResponse;
        }

        // PUT: api/Agendamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgendamento(int id, AgendamentoDto agendamentoDto)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento == null) 
            {
                return NotFound();
            }
            

            if (DataExists(agendamentoDto.ServicoId, agendamentoDto.Data.Trim()) && agendamentoDto.Data.Trim() != agendamento.Data.Trim())
            {
                return BadRequest("Já existe um agendamento neste horário");
            }

            agendamento.Data = agendamentoDto.Data;
            agendamento.ServicoId = agendamentoDto.ServicoId;
            agendamento.ClienteId = agendamentoDto.ClienteId;
            agendamento.StatusId = agendamentoDto.StatusId;

            _context.Entry(agendamento).State = EntityState.Modified;
                
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendamentoExists(id))
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

        // POST: api/Agendamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult>PostAgendamento(AgendamentoDto agendamentoDto)
        {
          if (_context.Agendamentos == null)
          {
              return Problem("Entity set 'AgendamentoContext.Agendamentos'  is null.");
          }

            if (DataExists(agendamentoDto.ServicoId, agendamentoDto.Data)) 
            {
                return BadRequest("Já existe um agendamento neste horário");
            }
            Agendamento agendamento = new Agendamento(agendamentoDto.Data, agendamentoDto.ServicoId, agendamentoDto.ClienteId, agendamentoDto.StatusId);
            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();

            

            return Ok("Sucesso ao criar");
        }

        // DELETE: api/Agendamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendamento(int id)
        {
            if (_context.Agendamentos == null)
            {
                return NotFound();
            }
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }

            _context.Agendamentos.Remove(agendamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AgendamentoExists(int id)
        {
            return (_context.Agendamentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private  bool DataExists(int idServico, string data) 
        {
            var dataExists = _context.Agendamentos.ToList();
             
            foreach (var item in dataExists) 
            {
                if (item.ServicoId == idServico && item.Data.Trim() == data.Trim())
                {
                    return true ;
                    
                }
            }
            return false;
        }
    }
}
