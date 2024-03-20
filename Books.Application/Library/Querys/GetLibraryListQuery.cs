using Books.Application.Library.DTOs;
using MediatR;

namespace Books.Application.Queries.Library
{
    public class GetLibraryListQuery : IRequest<List<LibraryReadModel>>
    {

    }
}