namespace Domain {
    public class ClienteRepetidoException : Exception {
        public ClienteRepetidoException()
        {
        }
        public ClienteRepetidoException(string? message): base(message)
        {
        }
        public ClienteRepetidoException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}