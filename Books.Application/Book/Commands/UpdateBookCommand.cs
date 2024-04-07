using Books.Application.Book.DTOs;
using Books.Domain.Exceptions;
using Books.Infrastructure.Contexts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Books.Application.Book.Commands;
public class UpdateBookCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public BookUpdateModel Values;

    public UpdateBookCommand(
        Guid id,
        BookUpdateModel values
    )
    {
        Id = id;
        Values = values;
    }
}

public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, Guid>
{
    private readonly DbContextPostgres _context;
    public UpdateBookHandler(DbContextPostgres bookRepository)
    {
        _context = bookRepository;
    }
    public async Task<Guid> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
    {
        var values = command.Values;
        var currentEntity = await _context.Books
            .Where(c => c.Id == command.Id)
            .FirstOrDefaultAsync();

        if (currentEntity is null)
        {
            throw new CustomException(
                    StatusCodes.Status404NotFound,
                    "Book",
                    new
                    {
                        Message = "Livo não encontrado ou não existe"
                    });
        }

        currentEntity.Name = values.Name;
        currentEntity.Description = values.Description;
        currentEntity.PublishingCompany = values.PublishingCompany;
        currentEntity.PublishYear = values.PublishYear;
        currentEntity.Language = values.Language;
        currentEntity.PageNumber = values.PageNumber;

        _context.Books.Update(currentEntity);
        await _context.SaveChangesAsync();
        return command.Id;
    }
}