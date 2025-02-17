using AutoMapper;
using Books.Application.Library.DTOs;
using Books.Domain.Entities;

namespace Books.Infrastructure.LibraryMapper;

public class LibraryMapper : Profile
{
    public LibraryMapper()
    {
        CreateMap<Library, GetLibraryListQueryDto>().ReverseMap();
        CreateMap<Library, GetLibraryByIdQueryDto>()
            .ForMember(dest => dest.BookIds, opt => opt.MapFrom(c => c.Books.Select(c => c.Id)))
            .ReverseMap();
        CreateMap<LibraryCreateModel, Library>();
        CreateMap<AddressCreateModel, Address>().ReverseMap();
        CreateMap<AddressReadModel, Address>().ReverseMap();
    }
}