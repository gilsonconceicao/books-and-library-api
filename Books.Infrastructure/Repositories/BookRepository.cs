using AutoMapper;
using Books.Application.DTOs;
using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Books.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure.Repositories;

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

    public async Task<List<BookReadModel>> GetBookListAsync()
    {
        var books = _mapper.Map<List<BookReadModel>>(await _dbContext.Books.ToListAsync()); 
        return books; 
    }
}