namespace Domain {
    public class ConcessionariaRepetidaException : Exception {
        public ConcessionariaRepetidaException()
        {
        }
        public ConcessionariaRepetidaException(string? message): base(message)
        {
        }
        public ConcessionariaRepetidaException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}