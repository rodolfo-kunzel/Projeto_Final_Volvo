namespace Domain{
    public class ClienteNaoPodeSerDeletadoException : Exception {
        public ClienteNaoPodeSerDeletadoException()
        {
        }
        public ClienteNaoPodeSerDeletadoException(string? message): base(message)
        {
        }
        public ClienteNaoPodeSerDeletadoException(string? message, Exception? inner): base(message, inner)
        {
        }
    }
}