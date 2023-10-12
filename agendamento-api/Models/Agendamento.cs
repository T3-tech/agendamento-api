using System.ComponentModel.DataAnnotations;

namespace agendamento_api.Models
{
    public class Agendamento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Data { get; set; }
        public Servico Servicos { get; set; }
        public Cliente Clientes { get; set; }
        public Status Status { get; set; }
    }
}
