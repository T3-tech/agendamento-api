using System.ComponentModel.DataAnnotations;

namespace agendamento_api.DtosRequest
{
    public class ClienteDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Cpf { get; set; }
    }
}
