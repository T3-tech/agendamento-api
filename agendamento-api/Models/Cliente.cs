using System.ComponentModel.DataAnnotations;

namespace agendamento_api.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public string Cpf { get; set; }
        public ICollection<Agendamento> Agendamentos { get; set; }


        public Cliente(string nome, string telefone, string cpf)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.Cpf = cpf;
        }
    }
}
