
using Books.Application.DTOs.Book;
using MediatR;

namespace Books.Application.Queries.Book
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