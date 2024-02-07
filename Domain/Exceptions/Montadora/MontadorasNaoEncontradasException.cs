namespace Domain {
    public class MontadorasNaoEncontradasException : Exception {
        public MontadorasNaoEncontradasException()
        {
        }
        public MontadorasNaoEncontradasException(string? message): base(message)
        {
        }
        public MontadorasNaoEncontradasException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}