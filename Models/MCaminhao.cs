using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final_Volvo{
    public class MCaminhao
    {
        [Key]
        public string idCaminhao {get;}
        public int valor {get;set;}
        public int numeroChassi {get;set;}
        public string cor {get;set;}
        [ForeignKey("ModeloCaminhao")]
        public int idModelo{ get; set;}
        public MModeloCaminhao? modeloCaminhao { get; set;}
        [ForeignKey("Montadora")]
        public int idMontadora{ get; set;}
        public MMontadora? montadora { get; set;}
        [ForeignKey("Concessionaria")]
        public int idConcessionaria{ get; set;}
        public MConcessionaria? concessionaria { get; set;}

    }
}