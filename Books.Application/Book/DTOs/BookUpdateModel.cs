using Books.Application.Enums;

namespace Books.Application.Book.DTOs;
#nullable disable
public class BookUpdateModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string PublishingCompany { get; set; }
    public string PublishYear { get; set; }
    public string Language { get; set; }
    public string PageNumber { get; set; }
    public StatusAvailability StatusAvailability { get; set; }
    public Format Format { get; set; }
}
