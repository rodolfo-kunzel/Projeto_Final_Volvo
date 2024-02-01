using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concessionaria.Models
{
    public class MConcessionaria
    {
          public int Id {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14)]
        public required string CNPJ {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(100)]
        public required string Email {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(15)]
        public required string Telefone {get;set;}
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int EnderecoId{ get; set;}
        public MEndereco? Endereco { get; set;}

        public ICollection<MCaminhao>? Caminhoes { get; set;}

        [NotMapped]
        public double Faturamento { get; set; }
    }
}
