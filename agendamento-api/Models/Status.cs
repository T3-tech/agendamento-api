using System.ComponentModel.DataAnnotations;

namespace agendamento_api.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
