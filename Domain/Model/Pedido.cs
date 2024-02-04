using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Pedido
    {
        public int Id {get;set;}

        [Required]
        public DateTime DataAbertura {get;set;}
        public DateTime? DataEntrega {get;set;}

        [Required]
        public int StatusPedido {get;set;}
        
        [Required]
        public int ClienteId{ get; set;}
        public Cliente? Cliente { get; set;}

        [Required]
        public required ICollection<Caminhao> Caminhoes { get; set;}
    }
}
