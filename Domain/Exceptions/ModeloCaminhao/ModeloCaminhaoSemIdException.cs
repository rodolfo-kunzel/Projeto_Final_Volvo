namespace Domain{
    public class ModeloCaminhaoSemIdException : Exception {
        public ModeloCaminhaoSemIdException()
        {
        }
        public ModeloCaminhaoSemIdException(string? message): base(message)
        {
        }
        public ModeloCaminhaoSemIdException(string? message, Exception? inner): base(message, inner)
        {
        }

    }
}