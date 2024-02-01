using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final_Volvo{
    public class MConcessionaria
    {
        [Key]
        public string idConcessionaria {get;}
        public string CNPJ {get;set;}
        public string email {get;set;}
        public string telefone {get;set;}
        
        [ForeignKey("Endereco")]
        public int idEndereco{ get; set;}
        public MEndereco? endereco { get; set;}
        [ForeignKey("Caminhao")]
        public int idCaminhao{ get; set;}
        public MCaminhao? caminhao { get; set;}

    }
}
