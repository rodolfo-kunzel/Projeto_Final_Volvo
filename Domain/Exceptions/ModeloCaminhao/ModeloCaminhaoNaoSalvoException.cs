namespace Domain{ 
        public class ModeloCaminhaoNaoSalvoException : Exception {
        public ModeloCaminhaoNaoSalvoException()
        {
        }
        public ModeloCaminhaoNaoSalvoException(string? message): base(message)
        {
        }
        public ModeloCaminhaoNaoSalvoException(string? message, Exception? inner): base(message, inner)
        {
        }
        
     }
}