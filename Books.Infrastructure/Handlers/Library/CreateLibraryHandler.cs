using Books.Application.Commands.Library;
using Books.Application.DTOs.Library;
using Books.Application.Exceptions;
using Books.Domain.Interfaces;
using MediatR;

namespace Books.Infrastructure.Handlers.Library
{
    public class CreateLibraryHandler : IRequestHandler<CreateLibraryCommand, LibraryCreateModel>
    {
        private readonly ILibraryRepository _libraryRepository; 
        public CreateLibraryHandler(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }
        public async Task<LibraryCreateModel> Handle(CreateLibraryCommand command, CancellationToken cancellationToken)
        {
            var library = command.values; 

            await _libraryRepository.CreateAsync(library); 

            return library;
        }
    }
}