namespace Domain{
    public class PedidoNaoPodeSerDeletadoException : Exception {
        public PedidoNaoPodeSerDeletadoException()
        {
        }
        public PedidoNaoPodeSerDeletadoException(string? message): base(message)
        {
        }
        public PedidoNaoPodeSerDeletadoException(string? message, Exception? inner): base(message, inner)
        {
        }
    }
}