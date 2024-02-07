namespace Domain {
    public class PedidosNaoEncontradosException : Exception {
        public PedidosNaoEncontradosException()
        {
        }
        public PedidosNaoEncontradosException(string? message): base(message)
        {
        }
        public PedidosNaoEncontradosException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}