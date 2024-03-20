using AutoMapper;
using Books.Application.Book.DTOs;
using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Books.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure.Repositories;
#nullable disable
public class BookRepository : IBookRepository
{
    private readonly DbContextPostgres _dbContext; 
    private readonly IMapper _mapper;

    public BookRepository(DbContextPostgres context, IMapper mapper)
    {
        _dbContext = context;        
        _mapper = mapper; 
    }

    public async Task CreateAsync(BookCreateModel model)
    {
        Book book = _mapper.Map<BookCreateModel, Book>(model);

        await _dbContext.Books.AddAsync(book);
        await _dbContext.SaveChangesAsync(); 
    }

    public async Task Delete(Book model)
    {
        _dbContext.Books.Remove(model);
        await _dbContext.SaveChangesAsync();
    }

    public Task<Book> GetBookByIdAsync(Guid id)
    {
        return _dbContext.Books.FirstOrDefaultAsync(item => item.Id == id); 
    }

    public async Task<List<BookReadModel>> GetBookListAsync(string Name)
    {
        List<Book> query = await _dbContext.Books.ToListAsync(); 
        
        if (Name is not null)
        {
            query =  query.Where(item => item.Name.Contains(Name)).ToList();
        }

        return _mapper.Map<List<BookReadModel>>(query); 
    }

    public async Task UpdateAsync(BookUpdateModel model, Book currentModel)
    {
        currentModel.Description = model.Description; 
        currentModel.Name = model.Name; 
        currentModel.PublishingCompany = model.PublishingCompany; 
        currentModel.PublishYear = model.PublishYear; 
        currentModel.PageNumber = model.PageNumber; 
        currentModel.Language = model.Language; 
        currentModel.StatusAvailability = model.StatusAvailability; 
        currentModel.Format = model.Format; 

        _dbContext.Books.Update(currentModel);
        await _dbContext.SaveChangesAsync(); 
    }
}