namespace Books.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        // Propriedade para armazenar qualquer objeto personalizado
        public object CustomObject { get; }

        // Construtor que aceita uma mensagem de erro e um objeto personalizado
        public BadRequestException(string message, object customObject)
            : base(message)
        {
            CustomObject = customObject;
        }
    }
}