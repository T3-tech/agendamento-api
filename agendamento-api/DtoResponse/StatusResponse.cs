using System.Security.Cryptography.X509Certificates;

namespace agendamento_api.DtoResponse
{
    public class StatusResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }



        public StatusResponse(int id, string nome) 
        {
            this.Id = id;
            this.Nome = nome;
        }
    }

    
}
