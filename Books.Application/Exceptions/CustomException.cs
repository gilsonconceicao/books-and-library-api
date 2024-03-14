namespace Books.Application.Exceptions
{
    public class CustomException
    {
        public CustomException(string code, string message, List<ErrorMessage> details)
        {
            this.code = code;
            Message = message;
            Details = details;
        }

        public string code { get; set; }
        public string Message { get; set; }
        public List<ErrorMessage> Details {get; set;}
    } 
}

public class ErrorMessage
{
    public string Message { get; set; }
}