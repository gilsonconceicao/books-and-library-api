using System.Data.Entity;
using AutoMapper;
using Books.Application.Book.DTOs;
using Books.Application.Exceptions;
using Books.Infrastructure.Contexts;
using MediatR;

namespace Books.Application.Book.Querys;

public class GetBookByIdQuery : IRequest<BookReadModel>
{
    public Guid Id { get; set; }

    public GetBookByIdQuery(Guid id)
    {
        this.Id = id;
    }
}

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookReadModel>
    {
        private readonly DbContextPostgres _context; 
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(DbContextPostgres context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper; 
        }

        public async Task<BookReadModel> Handle(GetBookByIdQuery command, CancellationToken cancellationToken)
        {
            var entity = await _context.Books
                .Where( c => c.Id == command.Id)
                .FirstOrDefaultAsync();

            if (entity is null)
            {
                throw new NotFoundException($"Livro não encontrado ou não existe.");
            }
            
            return _mapper.Map<BookReadModel>(entity); 
        }
    }