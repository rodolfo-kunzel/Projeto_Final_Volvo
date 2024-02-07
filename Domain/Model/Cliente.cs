using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Cliente
    {
        public int Id {get;set;}

        [Required]
        [MaxLength(100)]
        public required string Nome {get;set;}

        [Required]
        [MaxLength(14)]
        public required string NumeroDocumento {get;set;}

        [Required]
        [MaxLength(15)]
        public required string Telefone {get;set;}

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public required string Email {get;set;}
        
        [Required]
        public int EnderecoId{ get; set;}
        public Endereco? Endereco { get; set;}

        public ICollection<Pedido>? Pedidos { get; set;}
    }
}
