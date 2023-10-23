using System.ComponentModel.DataAnnotations;

namespace agendamento_api.Models
{
    public class Agendamento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Data { get; set; }
        [Required]
        public int ServicoId { get; set; }
        public virtual Servico Servicos { get; set; }
        [Required]
        public int ClienteId { get; set; }
        public virtual Cliente Clientes { get; set; }
        [Required]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
