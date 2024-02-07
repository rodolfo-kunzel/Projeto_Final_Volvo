namespace Domain{
    public class ClienteNuloException : Exception {
        public ClienteNuloException()
        {
        }
        public ClienteNuloException(string? message): base(message)
        {
        }
        public ClienteNuloException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}