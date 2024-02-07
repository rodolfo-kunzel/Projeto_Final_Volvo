namespace Domain{
    public class PedidoNuloException : Exception {
        public PedidoNuloException()
        {
        }
        public PedidoNuloException(string? message): base(message)
        {
        }
        public PedidoNuloException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}