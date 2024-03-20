using Books.Application.Library.DTOs;
using Books.Application.Queries.Library;
using Books.Domain.Interfaces;
using Books.Infrastructure.Contexts;
using MediatR;

namespace Books.Infrastructure.Handlers.Library
{
    public class GetLibraryListQueryHandler : IRequestHandler<GetLibraryListQuery, List<LibraryReadModel>>
    {
        private readonly ILibraryRepository _libraryRepository;
        public GetLibraryListQueryHandler(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository; 
        }

        public async Task<List<LibraryReadModel>> Handle(GetLibraryListQuery request, CancellationToken cancellationToken)
        {
            return await _libraryRepository.GetLibraryListAsync();
        }
    }
}