using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final_Volvo
{
    public class MModeloCaminhao
    {
        public int Id {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(30)]
        public required string Nome {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(30)]
        public required string Cabine {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(30)]
        public required string Motor {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(30)]
        public required string Transmissao {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(30)]
        public required string Tanque {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(30)]
        public required string Eixo {get;set;}

        public required ICollection<MCaminhao> Caminhoes { get; set;}
    }
}