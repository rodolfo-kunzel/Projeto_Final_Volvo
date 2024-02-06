namespace Domain {
    public class CaminhaoNuloOuVazioException : Exception {
        public CaminhaoNuloOuVazioException()
        {
        }
        public CaminhaoNuloOuVazioException(string? message): base(message)
        {
        }
        public CaminhaoNuloOuVazioException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}