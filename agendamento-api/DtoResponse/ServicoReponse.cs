using agendamento_api.Models;

namespace agendamento_api.DtoResponse
{
    public class ServicoReponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public string NomeProfissional { get; set; }

        public ServicoReponse(int id,string nome,double valor, string nomeProfissional) {
            this.Id = id;
            this.Nome = nome;
            this.Valor = valor;
            this.NomeProfissional = nomeProfissional;
        }
    }
}
