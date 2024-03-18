using Books.Application.DTOs.Library;
using Books.Domain.Entities;

namespace Books.Domain.Interfaces
{
    public interface ILibraryRepository
    {
        public Task CreateAsync(LibraryCreateModel model);
        public Task UpdateAsync(LibraryUpdateModel model, Library currentModel);
        public Task<List<LibraryReadModel>> GetLibraryListAsync();
        public Task<Library> GetLibraryByIdAsync(Guid id);
        public Task Delete(Library Model);
    }
}