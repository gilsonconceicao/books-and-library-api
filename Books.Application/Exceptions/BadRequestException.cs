namespace Books.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public object CustomObject { get; }
        public BadRequestException(string message, object customObject)
            : base(message)
        {
            CustomObject = customObject;
        }
    }
}