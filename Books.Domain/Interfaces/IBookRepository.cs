using Books.Application.DTOs;

namespace Books.Domain.Interfaces
{
    public interface IBookRepository
    {
        public Task CreateAsync(BookCreateModel model);
        public Task<List<BookReadModel>> GetBookListAsync();
    }
}