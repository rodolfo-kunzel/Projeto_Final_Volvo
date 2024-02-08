namespace Domain {
    public class FaturamentosNaoEncontradosException : Exception {
        public FaturamentosNaoEncontradosException()
        {
        }
        public FaturamentosNaoEncontradosException(string? message): base(message)
        {
        }
        public FaturamentosNaoEncontradosException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}