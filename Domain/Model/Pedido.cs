using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Pedido
    {
        public int Id {get;set;}

        [Required]
        public DateTime DataAbertura {get;set;} = DateTime.Now;
        [DefaultValue(null)]
        public DateTime? DataEntrega {get;set;}

        [Required]
        [DefaultValue(0)]
        public int StatusPedido {get;set;}
        
        [Required]
        public int ClienteId{ get; set;}
        public Cliente? Cliente { get; set;}

        public ICollection<Caminhao>? Caminhoes { get; set;}

        [NotMapped]
        public required List<int> ListaCaminhoes { get; set;}
    }
}
