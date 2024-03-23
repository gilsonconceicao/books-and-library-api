
using AutoMapper;
using Books.Infrastructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Books.Application.Book.Querys;

#nullable disable
public class GetBooksListQuery : IRequest<List<Books.Domain.Entities.Book>>
{
    public GetBooksListQuery(string Name)
    {
        this.Name = Name;
    }
    public string? Name { get; set; }
}

public class GetBooksListQueryHandler : IRequestHandler<GetBooksListQuery, List<Books.Domain.Entities.Book>>
{
    private readonly DbContextPostgres _context;
    private readonly IMapper _mapper;

    public GetBooksListQueryHandler(DbContextPostgres context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Books.Domain.Entities.Book>> Handle(GetBooksListQuery queryParams, CancellationToken cancellationToken)
    {
        var query = await _context.Books
            .ToListAsync();
        return query;
    }
}