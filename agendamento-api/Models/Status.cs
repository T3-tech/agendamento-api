using System.ComponentModel.DataAnnotations;

namespace agendamento_api.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; }


        public Status(string nome) {
            this.Nome = nome;
        }
        public Status(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
    }
}
