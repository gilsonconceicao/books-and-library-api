
using AutoMapper;
using Books.Application.Book.DTOs;
using Books.Infrastructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Books.Application.Book.Querys;

#nullable disable
public class GetBooksListQuery : IRequest<List<BookReadModel>>
{
    public GetBooksListQuery(string Name)
    {
        this.Name = Name;
    }
    public string Name { get; set; }
}

public class GetBooksListQueryHandler : IRequestHandler<GetBooksListQuery, List<BookReadModel>>
{
    private readonly DbContextPostgres _context;
    private readonly IMapper _mapper;

    public GetBooksListQueryHandler(DbContextPostgres context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<BookReadModel>> Handle(GetBooksListQuery queryParams, CancellationToken cancellationToken)
    {
        var query = await _context.Books
            .Where(b => b.Name.Contains(queryParams.Name))
            .ToListAsync();

        return _mapper.Map<List<BookReadModel>>(query);
    }
}