using AutoMapper;
using Books.Application.DTOs;
using Books.Domain.Entities;

namespace Books.Infrastructure.Mappers; 

class BookMapper : Profile 
{
    public BookMapper()
    {
        CreateMap<BookCreateModel, Book>();
        CreateMap<Book, BookReadModel>().ReverseMap();
    }
}