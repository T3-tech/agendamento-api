using System.ComponentModel.DataAnnotations;

namespace agendamento_api.DtosRequest
{
    public class AgendamentoDto
    {
        [Required]
        public string Data { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int ProfissionalId { get; set; }
        [Required]
        public int ServicoId { get; set; }
    }
}
