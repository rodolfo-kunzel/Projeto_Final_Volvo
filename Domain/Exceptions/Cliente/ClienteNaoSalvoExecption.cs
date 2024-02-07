namespace Domain{
    public class ClienteNaoSalvoException : Exception {
        public ClienteNaoSalvoException()
        {
        }
        public ClienteNaoSalvoException(string? message): base(message)
        {
        }
        public ClienteNaoSalvoException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}