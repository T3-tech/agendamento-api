using System.ComponentModel.DataAnnotations;

namespace agendamento_api.Dtos
{
    public class ServicoDto
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public int ProfissionalId { get; set; }

        public ServicoDto(string nome, double valor, int profissionalId)
        {
            Nome = nome;
            Valor = valor;
            ProfissionalId = profissionalId;
        }
    }
}
