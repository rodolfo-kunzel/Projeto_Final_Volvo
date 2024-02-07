namespace Domain {
    public class MontadoraRepetidaException : Exception {
        public MontadoraRepetidaException()
        {
        }
        public MontadoraRepetidaException(string? message): base(message)
        {
        }
        public MontadoraRepetidaException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}