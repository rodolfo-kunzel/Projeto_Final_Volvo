using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final_Volvo
{
    public class MMontadora
    {
        public int Id {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14)]
        public required string CNPJ {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(100)]
        public required string Email {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Comissao {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int EnderecoId{ get; set;}
        public MEndereco? Endereco { get; set;}

        public ICollection<MCaminhao>? Caminhoes { get; set;}

        [NotMapped]
        public double Repasse { get; set; }
    }
}
