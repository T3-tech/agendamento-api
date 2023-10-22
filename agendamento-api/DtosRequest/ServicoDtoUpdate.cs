using System.ComponentModel.DataAnnotations;
namespace agendamento_api.DtosRequest
{
    public class ServicoDtoUpdate
    {
        public int Id { get;set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public int ProfissionalId { get; set; }

        public ServicoDtoUpdate(int id, string nome, double valor, int profissionalId)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
            ProfissionalId = profissionalId;
        }
    }
}
