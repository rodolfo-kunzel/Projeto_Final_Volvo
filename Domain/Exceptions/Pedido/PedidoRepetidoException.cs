namespace Domain {
    public class PedidoRepetidoException : Exception {
        public PedidoRepetidoException()
        {
        }
        public PedidoRepetidoException(string? message): base(message)
        {
        }
        public PedidoRepetidoException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}