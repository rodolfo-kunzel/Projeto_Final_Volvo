namespace Domain{
    public class PedidoNuloOuVazioException : Exception {
        public PedidoNuloOuVazioException()
        {
        }
        public PedidoNuloOuVazioException(string? message): base(message)
        {
        }
        public PedidoNuloOuVazioException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}