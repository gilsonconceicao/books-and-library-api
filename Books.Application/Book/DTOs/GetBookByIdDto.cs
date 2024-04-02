

using Books.Application.Library.DTOs;
using Books.Domain.Enums;

namespace Books.Application.Book.DTOs;
#nullable disable
public class GetBookByIdDto
{
    public Guid Id { get; set; }
    public Guid LibraryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public StatusAvailability StatusAvailability { get; set; }
    public string StatusAvailabilityDisplay { get; set; }
    public Format Format { get; set; }
    public string FormatDisplay { get; set; }
    public object Library { get; set; }
}