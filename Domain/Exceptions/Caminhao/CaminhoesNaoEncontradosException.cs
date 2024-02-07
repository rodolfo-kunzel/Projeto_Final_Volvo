namespace Domain {
    public class CaminhoesNaoEncontradosException : Exception {
        public CaminhoesNaoEncontradosException()
        {
        }
        public CaminhoesNaoEncontradosException(string? message): base(message)
        {
        }
        public CaminhoesNaoEncontradosException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}