using AutoMapper;
using Books.Application.Book.DTOs;

namespace Books.Application.Library.DTOs;
#nullable disable
public class GetLibraryByIdQueryDto
{
    public Guid Id { get; set; }
    public List<Guid> BookIds { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Website { get; set; }
    public string PhotoUrl { get; set; }
    public IList<string> Catalogs { get; set; }
    public AddressReadModel Address { get; set; }
    public IList<BookToLibraryDto> Books { get; set; }
}