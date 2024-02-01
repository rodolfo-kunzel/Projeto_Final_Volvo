using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final_Volvo
{
    public class MEndereco
    {
        public int Id {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(30)]
        public string Estado {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(50)]
        public string Cidade {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(150)]
        public string Rua {get;set;}

        [MaxLength(20)]
        public string Complemento {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Numero {get;set;}
    }
}
