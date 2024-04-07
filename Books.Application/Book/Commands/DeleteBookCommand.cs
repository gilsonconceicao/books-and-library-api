using Books.Domain.Exceptions;
using Books.Infrastructure.Contexts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Books.Application.Book.Commands;

public class DeleteBookCommand : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteBookCommand(Guid id)
    {
        Id = id;
    }
}

 public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, Guid>
    {
        private readonly DbContextPostgres _context;

        public DeleteBookHandler(DbContextPostgres context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            var entity = await _context.Books
                .Where(c => c.Id == command.Id)
                .FirstOrDefaultAsync();

            if (entity is null)
            {
                throw new CustomException(
                    StatusCodes.Status404NotFound, 
                    "Book", 
                    new 
                    {
                        Message = "Livo não encontrado ou não existe"
                    });
            }

            _context.Books.Remove(entity);
            await _context.SaveChangesAsync();
            return command.Id;
        }
    }