namespace Domain{
    public class CaminhaoInvalidoException : Exception {
        public CaminhaoInvalidoException()
        {
        }
        public CaminhaoInvalidoException(string? message): base(message)
        {
        }
        public CaminhaoInvalidoException(string? message, Exception? inner): base(message, inner)
        {
        }
    }
}