using Books.Application.Exceptions;
using Books.Infrastructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Books.Application.Book.Querys;

public class GetBookByIdQuery : IRequest<Books.Domain.Entities.Book>
{
    public Guid Id { get; set; }

    public GetBookByIdQuery(Guid id)
    {
        this.Id = id;
    }
}

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Books.Domain.Entities.Book>
    {
        private readonly DbContextPostgres _context; 

        public GetBookByIdQueryHandler(DbContextPostgres context)
        {
            this._context = context;
        }

        public async Task<Books.Domain.Entities.Book> Handle(GetBookByIdQuery command, CancellationToken cancellationToken)
        {
            var entity = await _context.Books
                .Where( c => c.Id == command.Id)
                .FirstOrDefaultAsync();

            if (entity is null)
            {
                throw new NotFoundException($"Livro não encontrado ou não existe.");
            }
            
            return entity; 
        }
    }