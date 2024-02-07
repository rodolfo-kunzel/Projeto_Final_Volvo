namespace Domain{ 
        public class MontadoraNaoSalvaException : Exception {
        public MontadoraNaoSalvaException()
        {
        }
        public MontadoraNaoSalvaException(string? message): base(message)
        {
        }
        public MontadoraNaoSalvaException(string? message, Exception? inner): base(message, inner)
        {
        }
        
     }
}