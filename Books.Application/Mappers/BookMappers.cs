using AutoMapper;
using Books.Application.Book.DTOs;
using Books.Application.Services;
using Books.Domain.Entities;

namespace Books.Infrastructure.Mappers;

public class Mappers : Profile
{
    public Mappers()
    {
        CreateMap<Book, GetBookListDto>()
           .ForMember(dest => dest.StatusAvailabilityDisplay, opt => opt.MapFrom(src => EnumServices.GetEnumDescription(src.StatusAvailability)))
           .ForMember(dest => dest.FormatDisplay, opt => opt.MapFrom(src => EnumServices.GetEnumDescription(src.Format)))
           .ForMember(dest => dest.Library, opt => opt.MapFrom(src => MapCustomLibraryForList(src)));

        CreateMap<Book, BookToLibraryDto>()
           .ForMember(dest => dest.StatusAvailabilityDisplay, opt => opt.MapFrom(src => EnumServices.GetEnumDescription(src.StatusAvailability)))
           .ForMember(dest => dest.FormatDisplay, opt => opt.MapFrom(src => EnumServices.GetEnumDescription(src.Format))); 
           
        CreateMap<Book, GetBookByIdDto>()
           .ForMember(dest => dest.StatusAvailabilityDisplay, opt => opt.MapFrom(src => EnumServices.GetEnumDescription(src.StatusAvailability)))
           .ForMember(dest => dest.FormatDisplay, opt => opt.MapFrom(src => EnumServices.GetEnumDescription(src.Format)))
           .ForMember(dest => dest.Library, opt => opt.MapFrom(src => MapCustomLibrary(src)));
    }

    private static object? MapCustomLibrary(Book src)
    {
        var reference = src.Library;

        return new
        {
            Name = reference.Name,
            Catalogs = reference.Catalogs,
            PhoneNumber = reference.PhoneNumber,
            Id = reference.Id,
            Website = reference.Website,
            Address = reference.Address
        };
    }

    private static object? MapCustomLibraryForList(Book src)
    {
        var reference = src.Library;
        return new
        {
            Name = reference.Name,
            Address = reference.Address
        };
    }
}