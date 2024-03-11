using Books.Application.Commands;
using Books.Application.Exceptions;
using Books.Domain.Interfaces;
using MediatR;

namespace Books.Infrastructure.Handlers
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, Guid>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Guid> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            var entity = await _bookRepository.GetBookByIdAsync(command.Id);

            if (entity is null)
            {
                throw new NotFoundException($"Livro com o ID {command.Id} não encontrado.");
            }

            await _bookRepository.Delete(entity);
            return command.Id;
        }
    }
}