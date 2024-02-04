using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Endereco
    {
        public int Id {get;set;}

        [Required]
        [MaxLength(30)]
        public required string Estado {get;set;}

        [Required]
        [MaxLength(50)]
        public required string Cidade {get;set;}

        [Required]
        [MaxLength(150)]
        public required string Rua {get;set;}

        [MaxLength(20)]
        public string? Complemento {get;set;}

        [Required]
        public int Numero {get;set;}
    }
}
