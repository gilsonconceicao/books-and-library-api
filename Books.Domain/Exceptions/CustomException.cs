namespace Books.Domain.Exceptions;

public class CustomException : Exception
{
    public int StatusCode { get; set; }
    public string? Entity { get; init; }
    public object? Identifiers { get; init; }

    public CustomException(int statusCode, string entity, object identifiers)
        : base()
    {
        StatusCode = statusCode;
        Entity = entity;
        Identifiers = identifiers;
    }

    public CustomException(int statusCode, string entity, object identifiers, string Message)
        : base(Message)
    {
        StatusCode = statusCode;
        Entity = entity;
        Identifiers = identifiers;
    }
}
