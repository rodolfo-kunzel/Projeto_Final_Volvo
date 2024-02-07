using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Faturamento
    {
        public int Id { get;set; }

        [Required]
        public DateTime DataFatura{ get;set; }

        [Required]
        [DefaultValue(0)]
        public double ValorFatura { get;set; }

        public int ConcessionariaId { get; set; }
        public Concessionaria? Concessionaria { get; set; }

        public int MontadoraId { get; set; }
        public Montadora? Montadora { get; set; }

        [NotMapped]
        public ICollection<Pedido>? Pedidos { get; set; }
    }
}