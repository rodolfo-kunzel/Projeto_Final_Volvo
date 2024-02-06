namespace Domain{
    public class ClienteNuloOuVazioException : Exception {
        public ClienteNuloOuVazioException()
        {
        }
        public ClienteNuloOuVazioException(string? message): base(message)
        {
        }
        public ClienteNuloOuVazioException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}