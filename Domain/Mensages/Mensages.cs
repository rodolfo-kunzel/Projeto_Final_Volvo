namespace Domain {
    public class Mensagens {

        //Geral
        public static string erroDados = "Erro ocorreu ao tentar acessar o banco de dados";
        public static string erroInesparo = "Ocorreu um erro inesperado";
        public static string CNPJExistente = "CNPJ já cadastrado!";


        // Caminhao
        public static string numeroChassiExistente = "Numero de Chassi já cadastrado!";
        public static string caminhaoNulo = "O Caminhão selecionado não existe";
        public static string listaCaminhoesVazia = "Nenhum caminhão foi encontrado";
        public static string erroNaBuscaDeCaminhoes = "Erro ao tentar recuperar caminhoes";
        public static string erroAoSalvarCaminhao = "Ocorreu um erro ao salvar o caminhão";
        public static string caminhaoRemovidoErro = "Não foi possivel deletar o caminhao";
        public static string caminhaoRemovidoSucesso = "O caminhao foi deletado com sucesso!";

        //Cliente
        public static string numeroDocumentoExistente = "Numero do documento já cadastrado!";
        public static string listaClientesVazia = "Nenhum cliente foi encontrado";
        public static string clienteNulo = "O cliente selecionado não existe";
        public static string erroNaBuscaDeClientes = "Erro ao tentar recuperar clientes";
        public static string erroAoSalvarCliente = "Ocorreu um erro ao salvar o cliente";
        public static string clienteRemovidoErro = "Não foi possivel deletar o cliente";
        public static string clienteRemovidoSucesso = "O cliente foi deletado com sucesso!";


        //Concessionaria
        public static string listaConcessionariasVazia = "Nenhuma Concessionaria foi encontrada";
        public static string concessionariaNula = "O concessionaria selecionada não existe";
        public static string erroNaBuscaDeConcessionarias = "Erro ao tentar recuperar concessionarias";
        public static string erroAoSalvarConcessionaria = "Ocorreu um erro ao salvar a concessionaria";
        public static string concessionariaRemovidaErro = "Não foi possivel deletar a concessionaria";
        public static string concessionariaRemovidoSucesso = "A Concessionaria foi deletada com sucesso!";


        //Modelo Caminhao
        public static string modeloCaminhaoNulo = "O modelos de caminhão selecionado não existe";
        public static string listaModelosCaminhoesVazia = "Nenhum modelos de caminhão foi encontrado";
        public static string erroNaBuscaDeModelosCaminhoes = "Erro ao tentar recuperar modelos de caminhões";
        public static string erroAoSalvarModeloCaminhao = "Ocorreu um erro ao salvar o modelo de caminhão";
        public static string modeloCaminhaoRemovidoErro = "Não foi possivel deletar o modelo de caminhão";
        public static string modeloCaminhaoRemovidoSucesso = "O modelo de caminhão foi deletado com sucesso!";


        // Montadora
        public static string montadoraNulo = "A montadora selecionada não existe";
        public static string listaMontadorasVazia = "Nenhuma montadora foi encontrada";
        public static string erroNaBuscaDeMontadora = "Occoreu um erro ao tentar recuperar a montadora";
        public static string erroAoSalvarMontadora = "Ocorreu um erro ao salvar a montadora";
        public static string montadoraRemovidaErro = "Não foi possivel deletar o motadora";
        public static string montadoraRemovidoSucesso = "A montadora foi deletada com sucesso!";


        //Pedido

        public static string pedidoNulo = "O pedido selecionado não existe";
        public static string listaPedidosVazia = "Nenhuma pedido foi encontrado";
        public static string erroNaBuscaDePedido = "Occoreu um erro ao tentar recuperar o pedido";
        public static string erroAoSalvarPedido = "Ocorreu um erro ao salvar o pedido";
        public static string pedidoRemovidaErro = "Não foi possivel deletar o pedido";
        public static string pedidoRemovidoSucesso = "O pedido foi deletado com sucesso!";
        public static string pedidoIdInvalido = "O id do pedido é inválido";

    }
}