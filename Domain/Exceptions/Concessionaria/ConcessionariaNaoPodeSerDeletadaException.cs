namespace Domain{
    public class ConcessionariaNaoPodeSerDeletadaException : Exception {
        public ConcessionariaNaoPodeSerDeletadaException()
        {
        }
        public ConcessionariaNaoPodeSerDeletadaException(string? message): base(message)
        {
        }
        public ConcessionariaNaoPodeSerDeletadaException(string? message, Exception? inner): base(message, inner)
        {
        }
    }
}