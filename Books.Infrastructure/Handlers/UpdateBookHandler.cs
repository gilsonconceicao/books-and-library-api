using Books.Application.Commands;
using Books.Application.DTOs;
using Books.Application.Exceptions;
using Books.Domain.Interfaces;
using MediatR;

namespace Books.Infrastructure.Handlers
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, Guid>
    {
        private readonly IBookRepository _bookRepository;
        public UpdateBookHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<Guid> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var currentModel = await _bookRepository.GetBookByIdAsync(command.Id);

            if (currentModel is null)
            {
                throw new NotFoundException($"Livro com o ID {command.Id} não encontrado.");
            }

            BookUpdateModel model = new BookUpdateModel()
            {
                Description = command.Description,
                Name = command.Name
            };

            await _bookRepository.UpdateAsync(model, currentModel);

            return command.Id;
        }
    }
}