namespace Domain {
    public class FaturamentoRepetidoException : Exception {
        public FaturamentoRepetidoException()
        {
        }
        public FaturamentoRepetidoException(string? message): base(message)
        {
        }
        public FaturamentoRepetidoException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}