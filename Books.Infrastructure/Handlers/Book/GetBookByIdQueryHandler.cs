using AutoMapper;
using Books.Application.Book.DTOs;
using Books.Application.Book.Querys;
using Books.Application.Exceptions;
using Books.Domain.Interfaces;
using MediatR;

namespace Books.Infrastructure.Handlers.Book
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookReadModel>
    {
        private readonly IBookRepository _bookRepository; 
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            this._bookRepository = bookRepository;
            this._mapper = mapper; 
        }

        public async Task<BookReadModel> Handle(GetBookByIdQuery command, CancellationToken cancellationToken)
        {
            var entity = await _bookRepository.GetBookByIdAsync(command.Id);

            if (entity is null)
            {
                throw new NotFoundException($"Livro não encontrado ou não existe.");
            }
            
            return _mapper.Map<BookReadModel>(entity); 
        }
    }
}


//Adicionar o handler junto com o command/query dentro da application, adicionar o mapper diretamente no DTO