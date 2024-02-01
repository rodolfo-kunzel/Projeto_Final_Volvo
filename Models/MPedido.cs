using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final_Volvo
{
    public class MPedido
    {
        public int Id {get;set;}

        public DateTime DataAbertura {get;set;}
        public DateTime DataEntrega {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int StatusPedido {get;set;}
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int ClienteId{ get; set;}
        public MCliente? Cliente { get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public required ICollection<MCaminhao> Caminhoes { get; set;}
    }
}
