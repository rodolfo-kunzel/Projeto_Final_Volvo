using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final_Volvo
{
    public class MCaminhao
    {
        public int Id {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Valor {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(17)]
        public string NumeroChassi {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(20)]
        public string Cor {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int ModeloId{ get; set;}
        public MModeloCaminhao? Modelo { get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int MontadoraId{ get; set;}
        public MMontadora? Montadora { get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int ConcessionariaId{ get; set;}
        public MConcessionaria? Concessionaria { get; set;}
    }
}