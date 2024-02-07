namespace Domain{
    public class CaminhaoNaoPodeSerDeletadoException : Exception {
        public CaminhaoNaoPodeSerDeletadoException()
        {
        }
        public CaminhaoNaoPodeSerDeletadoException(string? message): base(message)
        {
        }
        public CaminhaoNaoPodeSerDeletadoException(string? message, Exception? inner): base(message, inner)
        {
        }
    }
}