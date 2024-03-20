
using Books.Application.Library.DTOs;

namespace Books.Application.Library.DTOs;
#nullable disable
public class LibraryUpdateModel
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Website { get; set; }
    public string PhotoUrl { get; set; }
    public List<string> Catalogs { get; set; }
    public virtual AddressCreateModel Address { get; set; }
}