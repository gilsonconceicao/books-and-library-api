using AutoMapper;
using Books.Application.Library.DTOs;
using Books.Domain.Entities;

namespace Books.Infrastructure.LibraryMapper; 

public class LibraryMapper : Profile 
{
    public LibraryMapper()
    {
        CreateMap<Library, LibraryReadModel>();
    }
}