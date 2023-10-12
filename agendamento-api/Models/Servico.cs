using System.ComponentModel.DataAnnotations;

namespace agendamento_api.Models
{
    public class Servico
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public double Valor { get; set; }
        public Profissional Profissional { get; set; } = null!;

    }
}
