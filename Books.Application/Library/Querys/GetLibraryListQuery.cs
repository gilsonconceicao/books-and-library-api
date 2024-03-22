using AutoMapper;
using Books.Application.Library.DTOs;
using Books.Infrastructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Books.Application.Queries.Library;

public class GetLibraryListQuery : IRequest<List<LibraryReadModel>>
{

}

public class GetLibraryListQueryHandler : IRequestHandler<GetLibraryListQuery, List<LibraryReadModel>>
{
    private readonly DbContextPostgres _context;
    private readonly IMapper _mapper;

    public GetLibraryListQueryHandler(DbContextPostgres context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<LibraryReadModel>> Handle(GetLibraryListQuery request, CancellationToken cancellationToken)
    {
        var listLibrary = await _context.Librarys.ToListAsync();
        return _mapper.Map<List<LibraryReadModel>>(listLibrary);
    }
}
