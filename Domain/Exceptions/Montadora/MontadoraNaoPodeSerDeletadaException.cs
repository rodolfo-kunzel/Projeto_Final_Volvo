namespace Domain{
    public class MontadoraNaoPodeSerDeletadaException : Exception {
        public MontadoraNaoPodeSerDeletadaException()
        {
        }
        public MontadoraNaoPodeSerDeletadaException(string? message): base(message)
        {
        }
        public MontadoraNaoPodeSerDeletadaException(string? message, Exception? inner): base(message, inner)
        {
        }
    }
}