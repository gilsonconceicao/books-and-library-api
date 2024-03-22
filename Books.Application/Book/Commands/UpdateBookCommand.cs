using System.Data.Entity;
using Books.Application.Book.DTOs;
using Books.Application.Exceptions;
using Books.Infrastructure.Contexts;
using MediatR;

namespace Books.Application.Book.Commands;
public class UpdateBookCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public UpdateBookCommand(
        Guid id,
        string name,
        string description
    )
    {
        Id = id;
        Name = name;
        Description = description;
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
            var currentEntity = await _context.Books
                .Where(c => c.Id == command.Id)
                .FirstOrDefaultAsync();

            if (currentEntity is null)
            {
                throw new NotFoundException($"Livro não encontrado ou não existe.");
            }

            
        var newBookToSave = new Domain.Entities.Book()
        {
            Name = command.Name,
            Description = command.Description,
            // PublishingCompany = command.PublishingCompany,
            // PublishYear = command.PublishYear,
            // Language = command.Language,
            // PageNumber = command.PageNumber,
            // StatusAvailability = command.StatusAvailability,
            // Format = command.Format,
        };

            _context.Books.Update(currentEntity);
            return command.Id;
        }
    }