namespace Books.Application.Exceptions
{

    public class NotFoundException : Exception
    {
       public object CustomObject { get; }
        public NotFoundException(object customObject)
        {
            CustomObject = customObject;
        }
    }
}