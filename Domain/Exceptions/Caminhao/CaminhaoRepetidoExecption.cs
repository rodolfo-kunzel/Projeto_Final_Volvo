namespace Domain{
        public class CaminhaoRepetidoException : Exception {
                public CaminhaoRepetidoException()
                {
                }
                public CaminhaoRepetidoException(string? message): base(message)
                {
                }
                public CaminhaoRepetidoException(string? message, Exception? inner): base(message, inner)
                {
                }
        }
}