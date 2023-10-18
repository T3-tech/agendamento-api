using agendamento_api.Dtos;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace agendamento_api.Models
{
    public class Profissional
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Telefone { get; set; }
        public virtual ICollection<Servico>? Servicos { get; set; }

        public Profissional(string nome, string telefone) {
            this.Nome = nome;
            this.Telefone = telefone;
        }
    }
}
