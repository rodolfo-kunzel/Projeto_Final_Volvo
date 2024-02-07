using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Montadora
    {
        public int Id { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 14)]
        public required string CNPJ { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public double Comissao { get; set; }

        [Required]
        public int EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }

        public int? FaturamentoId { get; set; }
        public Faturamento? Faturamento { get; set; }

        public ICollection<Caminhao>? Caminhoes { get; set; }
    }
}
