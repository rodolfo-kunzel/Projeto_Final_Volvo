namespace Domain {
    public class ConcessionariaNuloOuVazioException : Exception {
        public ConcessionariaNuloOuVazioException()
        {
        }
        public ConcessionariaNuloOuVazioException(string? message): base(message)
        {
        }
        public ConcessionariaNuloOuVazioException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}