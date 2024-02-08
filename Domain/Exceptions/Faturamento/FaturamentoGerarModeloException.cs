namespace Domain {
    public class FaturamentoGerarModeloException : Exception {
        public FaturamentoGerarModeloException()
        {
        }
        public FaturamentoGerarModeloException(string? message): base(message)
        {
        }
        public FaturamentoGerarModeloException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}