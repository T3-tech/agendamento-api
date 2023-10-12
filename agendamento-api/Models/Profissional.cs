using System.ComponentModel.DataAnnotations;

namespace agendamento_api.Models
{
    public class Profissional
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Telefone { get; set; }
    }
}
