namespace Domain{ 
        public class ConcessionariaNaoSalvaException : Exception {
        public ConcessionariaNaoSalvaException()
        {
        }
        public ConcessionariaNaoSalvaException(string? message): base(message)
        {
        }
        public ConcessionariaNaoSalvaException(string? message, Exception? inner): base(message, inner)
        {
        }
        
     }
}