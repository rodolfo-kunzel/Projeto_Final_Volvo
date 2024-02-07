namespace Domain {
    public class ModeloCaminhaoRepetidoException : Exception {
        public ModeloCaminhaoRepetidoException()
        {
        }
        public ModeloCaminhaoRepetidoException(string? message): base(message)
        {
        }
        public ModeloCaminhaoRepetidoException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}