using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Concessionaria
    {
        public int Id { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 14)]
        public required string CNPJ { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public required string Telefone { get; set; }

        [Required]
        public int EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }

        public ICollection<Caminhao>? Caminhoes { get; set; }

        [NotMapped]
        public double Faturamento { get; set; }
    }
}
