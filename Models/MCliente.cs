using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final_Volvo
{
    public class MCliente
    {
        public int Id {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(100)]
        public required string Nome {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(14)]
        public required string NumeroDocumento {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(15)]
        public required string Telefone {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(100)]
        public required string Email {get;set;}
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int EnderecoId{ get; set;}
        public MEndereco? Endereco { get; set;}

        public ICollection<MPedido>? Pedidos { get; set;}
    }
}
