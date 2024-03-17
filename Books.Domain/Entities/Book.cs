using Books.Application.Enums;

namespace Books.Domain.Entities; 

#nullable disable 
public class Book : Base
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int BookNumber { get; set; }
    public string PublishingCompany { get; set; }
    public string PublishYear { get; set; }
    public string Language { get; set; }
    public string PageNumber { get; set; }
    public StatusAvailability StatusAvailability { get; set; }
    public Format Format { get; set; }
    public virtual Library Library {get; set; }
    public Guid LibraryId {get; set; }
}