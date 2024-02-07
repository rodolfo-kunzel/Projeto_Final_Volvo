namespace Domain{
    public class ModeloCaminhaoNuloException : Exception {
        public ModeloCaminhaoNuloException()
        {
        }
        public ModeloCaminhaoNuloException(string? message): base(message)
        {
        }
        public ModeloCaminhaoNuloException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}