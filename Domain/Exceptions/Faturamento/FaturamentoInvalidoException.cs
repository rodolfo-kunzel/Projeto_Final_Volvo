namespace Domain {
    public class FaturamentoInvalidoException : Exception {
        public FaturamentoInvalidoException()
        {
        }
        public FaturamentoInvalidoException(string? message): base(message)
        {
        }
        public FaturamentoInvalidoException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}