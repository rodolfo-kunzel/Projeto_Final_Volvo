namespace Domain{
        public class CaminhaoSemIdException : Exception {
                public CaminhaoSemIdException()
                {
                }
                public CaminhaoSemIdException(string? message): base(message)
                {
                }
                public CaminhaoSemIdException(string? message, Exception? inner): base(message, inner)
                {
                }
        }
}