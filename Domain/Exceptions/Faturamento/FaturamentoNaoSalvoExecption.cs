namespace Domain{
    public class FaturamentoNaoSalvoException : Exception {
        public FaturamentoNaoSalvoException()
        {
        }
        public FaturamentoNaoSalvoException(string? message): base(message)
        {
        }
        public FaturamentoNaoSalvoException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}