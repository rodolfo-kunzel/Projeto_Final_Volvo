using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final_Volvo{
    public class MMontadora
    {
        [Key]
        public string idMontadora {get;}
        public string CNPJ {get;set;}
        public string email {get;set;}
        public double comissaoConssecionaria {get;set;}
        [ForeignKey("Endereco")]
        public int idEndereco{ get; set;}
        public MEndereco? endereco { get; set;}
        [ForeignKey("Caminhao")]
        public int idCaminhao{ get; set;}
        public MCaminhao? caminhao { get; set;}

    }
}
