using agendamento_api.Dtos;
using agendamento_api.Models;

namespace agendamento_api.DtoResponse
{
    public class ProfissionalResponse
    {
        public int Id { get; set; }
       
        public string Nome { get; set; }
        public List<ServicoDto> ListaServico { get; set; } = new List<ServicoDto>();


        public ProfissionalResponse(int id, string nome) {
            this.Id = id;
            this.Nome = nome;
        
        }
    }
}
