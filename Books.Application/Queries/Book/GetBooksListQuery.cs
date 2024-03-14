
using Books.Application.DTOs;
using MediatR;

namespace Books.Application.Queries.Book
{
    public class GetBooksListQuery : IRequest<List<BookReadModel>>
    {

    }
}