namespace Domain{ 
        public class PedidoNaoSalvoException : Exception {
        public PedidoNaoSalvoException()
        {
        }
        public PedidoNaoSalvoException(string? message): base(message)
        {
        }
        public PedidoNaoSalvoException(string? message, Exception? inner): base(message, inner)
        {
        }
        
     }
}