namespace Domain{ 
        public class ConcessionariaSemIdException : Exception {
        public ConcessionariaSemIdException()
        {
        }
        public ConcessionariaSemIdException(string? message): base(message)
        {
        }
        public ConcessionariaSemIdException(string? message, Exception? inner): base(message, inner)
        {
        }
        
     }
}