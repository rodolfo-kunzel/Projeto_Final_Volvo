namespace Domain {
    public class ConcessionariasNaoEncontradasException : Exception {
        public ConcessionariasNaoEncontradasException()
        {
        }
        public ConcessionariasNaoEncontradasException(string? message): base(message)
        {
        }
        public ConcessionariasNaoEncontradasException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}