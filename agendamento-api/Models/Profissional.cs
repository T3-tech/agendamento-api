using agendamento_api.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
        public string Cpf { get; set; }

        [Required]
        public string Telefone { get; set; }
        public virtual ICollection<Servico>? Servicos { get; set; }

        public Profissional(string nome, string telefone, string cpf) {
            this.Nome = nome;
            this.Telefone = telefone;
            this.Cpf = cpf;
        }

        public Profissional(int id, string nome, string telefone, string cpf) {
            this.Id = id;
            this.Nome = nome;
            this.Telefone = telefone;
            this.Cpf = cpf;
        }
    }
}
