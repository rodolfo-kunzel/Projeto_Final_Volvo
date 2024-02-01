using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Final_Volvo{
    public class MModeloCaminhao
    {
        [Key]
        public string idModeloCaminhao {get;}
        public string cabine {get;set;}
        public string motor {get;set;}
        public string transmissao {get;set;}
        public string eixo {get;set;}
        public string ferio {get;set;}
        public string suspensao {get;set;}
    }
}