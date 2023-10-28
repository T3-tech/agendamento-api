namespace agendamento_api.DtoResponse
{
    public class FaturamentoResponse
    {
       public string Data { get; set; }
       public string Servico { get; set; }
       public double Valor { get; set; }

        public FaturamentoResponse(string data, string servico, double valor) 
        {
            this.Data = data;
            this.Servico = servico;
            this.Valor = valor;
        }
    }
}
