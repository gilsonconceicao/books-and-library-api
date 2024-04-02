using AutoMapper;
using Books.Infrastructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Books.Application.Queries.Library;

public class GetLibraryListQuery : IRequest<List<Books.Domain.Entities.Library>>
{

}

public class GetLibraryListQueryHandler : IRequestHandler<GetLibraryListQuery, List<Books.Domain.Entities.Library>>
{
    private readonly DbContextPostgres _context;
    public GetLibraryListQueryHandler(DbContextPostgres context, IMapper mapper)
    {
        _context = context;
    }

    public async Task<List<Books.Domain.Entities.Library>> Handle(GetLibraryListQuery request, CancellationToken cancellationToken)
    {
        var listLibrary = await _context.Librarys.ToListAsync();
        return listLibrary;
    }
}
