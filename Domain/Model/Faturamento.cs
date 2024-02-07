using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Faturamento
    {
        public int Id { get;set; }

        [Required]
        public double ValorFaramento { get;set; }

        public int ConcessionariaId { get; set; }
        public Concessionaria? Concessionaria { get; set; }

        public int MontadoraId { get; set; }
        public Montadora? Montadora { get; set; }
    }
}