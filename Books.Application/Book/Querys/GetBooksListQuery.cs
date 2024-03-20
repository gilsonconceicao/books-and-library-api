
using Books.Application.Book.DTOs;
using MediatR;

namespace Books.Application.Book.Querys
{
    #nullable disable
    public class GetBooksListQuery : IRequest<List<BookReadModel>>
    {
        public GetBooksListQuery(string Name)
        {
            this.Name = Name;
        }
        public string Name {get; set;}
    }
}