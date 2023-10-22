using System.ComponentModel.DataAnnotations;

namespace agendamento_api.DtosRequest
{
    public class StatusDtoUpdate
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
