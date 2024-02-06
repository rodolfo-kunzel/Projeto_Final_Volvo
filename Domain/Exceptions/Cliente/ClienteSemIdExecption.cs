namespace Domain{
    public class ClienteSemIdException : Exception {
        public ClienteSemIdException()
        {
        }
        public ClienteSemIdException(string? message): base(message)
        {
        }
        public ClienteSemIdException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}