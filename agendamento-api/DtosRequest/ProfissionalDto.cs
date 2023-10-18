using System.ComponentModel.DataAnnotations;

namespace agendamento_api.Dtos
{
    public class ProfissionalDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }



        
    }
}
