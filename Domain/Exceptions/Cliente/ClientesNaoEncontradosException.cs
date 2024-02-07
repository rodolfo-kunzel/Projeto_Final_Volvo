namespace Domain {
    public class ClientesNaoEncontradosException : Exception {
        public ClientesNaoEncontradosException()
        {
        }
        public ClientesNaoEncontradosException(string? message): base(message)
        {
        }
        public ClientesNaoEncontradosException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}