namespace Domain {
    public class CaminhaoNuloException : Exception {
        public CaminhaoNuloException()
        {
        }
        public CaminhaoNuloException(string? message): base(message)
        {
        }
        public CaminhaoNuloException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}