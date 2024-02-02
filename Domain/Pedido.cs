using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Pedido
    {
        public int Id {get;set;}

        public DateTime DataAbertura {get;set;}
        public DateTime DataEntrega {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int StatusPedido {get;set;}
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int ClienteId{ get; set;}
        public Cliente? Cliente { get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public required ICollection<Caminhao> Caminhoes { get; set;}
    }
}
