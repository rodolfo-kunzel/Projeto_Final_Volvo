using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final_Volvo
{
    public class MModeloCaminhao
    {
        public int Id {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(30)]
        public string Nome {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(30)]
        public string Cabine {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(30)]
        public string Motor {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(30)]
        public string Transmissao {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(30)]
        public string Tanque {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(30)]
        public string Eixo {get;set;}
    }
}