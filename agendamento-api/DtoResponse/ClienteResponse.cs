namespace agendamento_api.DtoResponse
{
    public class ClienteResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Cpf { get; set; }


        public ClienteResponse(int id, string nome, string telefone, string cpf)
        {
            this.Id = id;
            this.Nome = nome;
            this.Telefone = telefone;
            this.Cpf = cpf;


        }
    }
}