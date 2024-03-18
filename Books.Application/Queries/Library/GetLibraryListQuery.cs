using Books.Application.DTOs.Library;
using MediatR;

namespace Books.Application.Queries.Library
{
    public class GetLibraryListQuery : IRequest<List<LibraryReadModel>>
    {

    }
}