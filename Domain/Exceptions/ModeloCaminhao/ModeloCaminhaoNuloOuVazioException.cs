namespace Domain{
    public class ModeloCaminhaoNuloOuVazioException : Exception {
        public ModeloCaminhaoNuloOuVazioException()
        {
        }
        public ModeloCaminhaoNuloOuVazioException(string? message): base(message)
        {
        }
        public ModeloCaminhaoNuloOuVazioException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}