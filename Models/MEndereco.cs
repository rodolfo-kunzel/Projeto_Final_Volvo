using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concessionaria.Models
{
    public class MEndereco
    {
        public int Id {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(30)]
        public required string Estado {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(50)]
        public required string Cidade {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(150)]
        public required string Rua {get;set;}

        [MaxLength(20)]
        public required string Complemento {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Numero {get;set;}
    }
}
