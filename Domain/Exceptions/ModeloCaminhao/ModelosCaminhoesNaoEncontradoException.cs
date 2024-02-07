namespace Domain {
    public class ModelosCaminhoesNaoEncontradoException : Exception {
        public ModelosCaminhoesNaoEncontradoException()
        {
        }
        public ModelosCaminhoesNaoEncontradoException(string? message): base(message)
        {
        }
        public ModelosCaminhoesNaoEncontradoException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}