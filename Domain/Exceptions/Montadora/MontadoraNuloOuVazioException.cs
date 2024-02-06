namespace Domain {
    public class MontadoraNuloOuVazioException : Exception {
        public MontadoraNuloOuVazioException()
        {
        }
        public MontadoraNuloOuVazioException(string? message): base(message)
        {
        }
        public MontadoraNuloOuVazioException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}