namespace Domain{
    public class AcessoDeDadosException : Exception {
        public AcessoDeDadosException()
        {
        }
        public AcessoDeDadosException(string? message): base(message)
        {
        }
        public AcessoDeDadosException(string? message, Exception? inner): base(message, inner)
        {
        }
        
    }
}