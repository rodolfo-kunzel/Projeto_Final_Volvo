namespace Domain {
    public class MontadoraNuloException : Exception {
        public MontadoraNuloException()
        {
        }
        public MontadoraNuloException(string? message): base(message)
        {
        }
        public MontadoraNuloException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}