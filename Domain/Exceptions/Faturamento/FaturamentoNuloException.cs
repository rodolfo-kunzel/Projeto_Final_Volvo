namespace Domain{
    public class FaturamentoNuloException : Exception {
        public FaturamentoNuloException()
        {
        }
        public FaturamentoNuloException(string? message): base(message)
        {
        }
        public FaturamentoNuloException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}