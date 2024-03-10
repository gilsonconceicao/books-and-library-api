using Books.Application.DTOs;
using Books.Application.Queries;
using Books.Domain.Interfaces;
using Books.Infrastructure.Repositories;
using MediatR;

namespace Books.Application.Handlers
{
    public class GetBooksHandler : IRequestHandler<GetBooksListQuery, List<BookReadModel>>
    {
        private readonly BookRepository _bookRepository;
        public GetBooksHandler(BookRepository bookRepository)
        {
            _bookRepository = bookRepository; 
        }

        public Task<List<BookReadModel>> Handle(GetBooksListQuery request, CancellationToken cancellationToken)
        {
           return _bookRepository.GetBookListAsync(); 
        }
    }
}