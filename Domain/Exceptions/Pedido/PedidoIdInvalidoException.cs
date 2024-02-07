namespace Domain{
    public class PedidoIdInvalidoException : Exception {
        public PedidoIdInvalidoException()
        {
        }
        public PedidoIdInvalidoException(string? message): base(message)
        {
        }
        public PedidoIdInvalidoException(string? message, Exception? inner): base(message, inner)
        {
        }
    }
}