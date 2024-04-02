

using Books.Domain.Enums;

namespace Books.Application.Book.DTOs;
#nullable disable
public class BookToLibraryDto
{
    public Guid Id { get; set; }
    public Guid LibraryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PublishingCompany { get; set; }
    public string PublishYear { get; set; }
    public string Language { get; set; }
    public string PageNumber { get; set; }
    public StatusAvailability StatusAvailability { get; set; }
    public string StatusAvailabilityDisplay { get; set; }
    public Format Format { get; set; }
    public string FormatDisplay { get; set; }
}