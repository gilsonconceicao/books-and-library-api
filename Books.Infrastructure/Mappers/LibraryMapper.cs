using AutoMapper;
using Books.Application.DTOs.Library;
using Books.Domain.Entities;

namespace Books.Infrastructure.Mappers; 

class LibraryMapper : Profile 
{
    public LibraryMapper()
    {
        CreateMap<LibraryCreateModel, Library>();
        CreateMap<Library, LibraryReadModel>().ReverseMap();
    }
}