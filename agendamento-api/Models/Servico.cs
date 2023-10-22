using agendamento_api.Dtos;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace agendamento_api.Models
{
    public class Servico
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public int ProfissionalId { get; set; }
        public virtual Profissional Profissional { get; set; }


        public Servico(string nome, double valor, int profissionalId) {
            this.Nome = nome;
            this.Valor = valor;
            this.ProfissionalId = profissionalId;
        }
        public Servico(int id, string nome, double valor, int profissionalId)
        {
            this.Id = id;
            this.Nome = nome;
            this.Valor = valor;
            this.ProfissionalId = profissionalId;
        }


    }
}
