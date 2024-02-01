using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final_Volvo{
    public class MPedido
    {
        [Key]
        public string idPedido {get;}
        public DateTime dateAbertura {get;set;}
        public DateTime dateEntrega {get;set;}
        public int statusPedido {get;set;}
        
        [ForeignKey("Cliente")]
        public int idCliente{ get; set;}
        public MCliente cliente { get; set;}
        [ForeignKey("Caminhao")]
        public int idCaminhao{ get; set;}
        public MCaminhao caminhao { get; set;}

    }
}
