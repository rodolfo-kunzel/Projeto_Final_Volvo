namespace Domain{
    public class PedidoSemIdException : Exception {
        public PedidoSemIdException()
        {
        }
        public PedidoSemIdException(string? message): base(message)
        {
        }
        public PedidoSemIdException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}