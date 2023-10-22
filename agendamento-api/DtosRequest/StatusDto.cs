using System.ComponentModel.DataAnnotations;

namespace agendamento_api.DtosRequest
{
    public class StatusDto
    {
        [Required]
        public string Nome { get; set; }




        public StatusDto(string nome) {

            this.Nome = nome;
        }
    }
}
