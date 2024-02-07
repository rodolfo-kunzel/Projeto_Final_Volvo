using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ModeloCaminhao
    {
        public int Id {get;set;}

        [Required]
        [MaxLength(30)]
        public required string Nome {get;set;}

        [Required]
        [MaxLength(30)]
        public required string Cabine {get;set;}

        [Required]
        [MaxLength(30)]
        public required string Motor {get;set;}

        [Required]
        [MaxLength(30)]
        public required string Transmissao {get;set;}

        [Required]
        [MaxLength(30)]
        public required string Tanque {get;set;}

        [Required]
        [MaxLength(30)]
        public required string Eixo {get;set;}

        public ICollection<Caminhao>? Caminhoes { get; set;}
    }
}