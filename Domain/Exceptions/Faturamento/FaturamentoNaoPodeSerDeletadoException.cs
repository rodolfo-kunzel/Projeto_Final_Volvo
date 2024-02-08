namespace Domain{
    public class FaturamentoNaoPodeSerDeletadoException : Exception {
        public FaturamentoNaoPodeSerDeletadoException()
        {
        }
        public FaturamentoNaoPodeSerDeletadoException(string? message): base(message)
        {
        }
        public FaturamentoNaoPodeSerDeletadoException(string? message, Exception? inner): base(message, inner)
        {
        }
    }
}