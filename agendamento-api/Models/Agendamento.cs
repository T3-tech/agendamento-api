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
        public int ClienteId { get; set; }
        public virtual Cliente Clientes { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
