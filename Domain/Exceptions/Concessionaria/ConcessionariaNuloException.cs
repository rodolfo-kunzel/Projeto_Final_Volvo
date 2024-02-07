namespace Domain {
    public class ConcessionariaNuloException : Exception {
        public ConcessionariaNuloException()
        {
        }
        public ConcessionariaNuloException(string? message): base(message)
        {
        }
        public ConcessionariaNuloException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}