using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final_Volvo{
    public class MCliente
    {
        [Key]
        public string idCliente {get;}
        public string nome {get;set;}
        public string numeroDocumentacao {get;set;}
        public string telefone {get;set;}
        public string email {get;set;}
        
        [ForeignKey("Endereco")]
        public int idEndereco{ get; set;}
        public MEndereco? endereco { get; set;}
    }
}
