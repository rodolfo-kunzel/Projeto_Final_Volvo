namespace Domain{
        public class MontadoraSemIdException : Exception {
        public MontadoraSemIdException()
        {
        }
        public MontadoraSemIdException(string? message): base(message)
        {
        }
        public MontadoraSemIdException(string? message, Exception? inner): base(message, inner)
        {
        }
        
     }
}