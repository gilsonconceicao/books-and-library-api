using Books.Application.Book.DTOs;
using Books.Domain.Entities;

namespace Books.Domain.Interfaces
{
    public interface IBookRepository
    {
        public Task CreateAsync(BookCreateModel model);
        public Task UpdateAsync(BookUpdateModel model, Book currentModel);
        public Task<List<BookReadModel>> GetBookListAsync(string Name);
        public Task<Book> GetBookByIdAsync(Guid id);
        public Task Delete(Book Model);
    }
}