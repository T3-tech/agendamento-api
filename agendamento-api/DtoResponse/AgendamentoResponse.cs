using Org.BouncyCastle.Asn1.Mozilla;
using System.Security.Cryptography.X509Certificates;

namespace agendamento_api.DtoResponse
{
    public class AgendamentoResponse
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public int StatusId {get;set;}
        public string StatusNome { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNome { get; set;}
        public int ServicoId { get; set; }
        public string ServicoNome { get; set;}
        public int ProfissionalId { get; set; }
        public string ProfissionalNome { get; set; }
        public double Valor { get; set; }

        public AgendamentoResponse() 
        {
        }
        public AgendamentoResponse(int id, string data, int statusId, string statusNome, int clienteId, string clienteNome, int servicoId, string servicoNome, int profissionalId, string profissionalNome, double valor)
        {
            Id = id;
            Data = data;
            StatusId = statusId;
            StatusNome = statusNome;
            ClienteId = clienteId;
            ClienteNome = clienteNome;
            ServicoId = servicoId;
            ServicoNome = servicoNome;
            ProfissionalId = profissionalId;
            ProfissionalNome = profissionalNome;
            Valor = valor;
        }
    }
}
