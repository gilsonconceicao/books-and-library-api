
using Books.Application.DTOs;
using MediatR;

namespace Books.Application.Queries
{
    public class GetBooksListQuery : IRequest<List<BookReadModel>>
    {

    }
}