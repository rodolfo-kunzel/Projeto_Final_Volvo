namespace Domain{
    public class CaminhaoNaoSalvoException : Exception {
        public CaminhaoNaoSalvoException()
        {
        }
        public CaminhaoNaoSalvoException(string? message): base(message)
        {
        }
        public CaminhaoNaoSalvoException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}