
using Books.Infrastructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Books.Application.Book.Querys;

#nullable disable
public class GetBooksListQuery : IRequest<List<Books.Domain.Entities.Book>>
{
    public GetBooksListQuery(string name, string description, string publishYear, string libraryName)
    {
        this.Name = name;
        this.Description = description;
        this.PublishYear = publishYear;
        this.LibraryName = libraryName;
    }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PublishYear { get; set; } = null; 
    public string? LibraryName { get; set; } = null; 
}

public class GetBooksListQueryHandler : IRequestHandler<GetBooksListQuery, List<Books.Domain.Entities.Book>>
{
    private readonly DbContextPostgres _context;

    public GetBooksListQueryHandler(DbContextPostgres context)
    {
        _context = context;
    }

    public async Task<List<Books.Domain.Entities.Book>> Handle(GetBooksListQuery query, CancellationToken cancellationToken)
    {
        var filterByName = !String.IsNullOrEmpty(query.Name);
        var filterByDescription = !String.IsNullOrEmpty(query.Description);
        var filterByPublishYear = !String.IsNullOrEmpty(query.PublishYear);
        var filterByLibraryName = !String.IsNullOrEmpty(query.LibraryName);

        var listSearchAny = new List<Books.Domain.Entities.Book>();
        var queryList = await _context.Books
            .Where(c => filterByName == false || c.Name.Contains(query.Name))
            .Where(c => filterByDescription == false || c.Description.Contains(query.Description))
            .Where(c => filterByPublishYear == false || c.PublishYear == query.PublishYear)
            .Where(c => filterByLibraryName == false || c.Library.Name.Contains(query.LibraryName))
            
            .ToListAsync();

        return queryList;
    }
}