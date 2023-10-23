using agendamento_api.Dtos;
using agendamento_api.Models;

namespace agendamento_api.DtoResponse
{
    public class ProfissionalResponse
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Cpf { get; set; }


        public List<Object> ListaServico { get; set; } = new List<Object>();


        public ProfissionalResponse(int id, string nome, string telefone, string cpf, List<Object> listaServico)
        {
            this.Id = id;
            this.Nome = nome;
            this.Telefone = telefone;
            this.Cpf = cpf;
            this.ListaServico = listaServico;
        }


        public ProfissionalResponse(int id, string nome, string telefone, string cpf)
        {
            this.Id = id;
            this.Nome = nome;
            this.Telefone = telefone;
            this.Cpf = cpf;
        }
    }
}
