using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Caminhao
    {
        public int Id {get;set;}

        [Required]
        public double Valor {get;set;}

        [Required]
        [StringLength(17)]
        public required string NumeroChassi {get;set;}

        [Required]
        [MaxLength(20)]
        public required string Cor {get;set;}

        [Required]
        public int ModeloId{ get; set;}
        public ModeloCaminhao? Modelo { get; set;}

        [Required]
        public int MontadoraId{ get; set;}
        public Montadora? Montadora { get; set;}

        [Required]
        public int ConcessionariaId{ get; set;}
        public Concessionaria? Concessionaria { get; set;}
    }
}