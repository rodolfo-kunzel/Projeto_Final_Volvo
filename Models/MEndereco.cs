using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final_Volvo{
    public class MEndereco
    {
        [Key]
        public string idEndereco {get;}
        public string estado {get;set;}
        public string cidade {get;set;}
        public string rua {get;set;}
        public string complemento {get;set;}
        public int numero {get;set;}
    }
}
