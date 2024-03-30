
using AutoMapper;
using Books.Infrastructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Books.Application.Book.Querys;

#nullable disable
public class GetBooksListQuery : IRequest<List<Books.Domain.Entities.Book>>
{
    public GetBooksListQuery(string name, string description, string publishYear)
    {
        this.Name = name;
        this.Description = description;
        this.PublishYear = publishYear;
    }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PublishYear { get; set; } = null; 
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

    public async Task<List<Books.Domain.Entities.Book>> Handle(GetBooksListQuery query, CancellationToken cancellationToken)
    {
        var filterByName = !String.IsNullOrEmpty(query.Name);
        var filterByDescription = !String.IsNullOrEmpty(query.Description);
        var filterByPublishYear = !String.IsNullOrEmpty(query.PublishYear);

        var listSearchAny = new List<Books.Domain.Entities.Book>();
        var queryList = await _context.Books
            .Where(c => filterByName == false || c.Name.Contains(query.Name))
            .Where(c => filterByDescription == false || c.Description.Contains(query.Description))
            .Where(c => filterByPublishYear == false || c.PublishYear == query.PublishYear)
            
            .ToListAsync();

        return queryList;
    }
}