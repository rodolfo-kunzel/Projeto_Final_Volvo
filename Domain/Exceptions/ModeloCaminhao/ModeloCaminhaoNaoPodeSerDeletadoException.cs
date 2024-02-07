namespace Domain{
    public class ModeloCaminhaoNaoPodeSerDeletadoException : Exception {
        public ModeloCaminhaoNaoPodeSerDeletadoException()
        {
        }
        public ModeloCaminhaoNaoPodeSerDeletadoException(string? message): base(message)
        {
        }
        public ModeloCaminhaoNaoPodeSerDeletadoException(string? message, Exception? inner): base(message, inner)
        {
        }
    }
}