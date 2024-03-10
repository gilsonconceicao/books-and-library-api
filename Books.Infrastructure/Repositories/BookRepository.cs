using Books.Application.DTOs.Create;
using Books.Domain.Interfaces;
using Books.Infrastructure.Contexts;

namespace Books.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly DbContextPostgres _dbContext; 

    public BookRepository(DbContextPostgres context)
    {
        _dbContext = context;         
    }
    public Task Create(BookCreateModel model)
    {
        throw new NotImplementedException();
    }
}