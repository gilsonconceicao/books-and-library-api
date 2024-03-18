using AutoMapper;
using Books.Application.DTOs.Library;
using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Books.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure.Repositories
{
    #nullable disable
    public class LibraryRepository : ILibraryRepository
    {
        private readonly DbContextPostgres _dbContext;
        private readonly IMapper _mapper;
        public LibraryRepository(DbContextPostgres context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task CreateAsync(LibraryCreateModel model)
        {
            Library library = _mapper.Map<LibraryCreateModel, Library>(model);

            await _dbContext.Librarys.AddAsync(library);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Library model)
        {
            _dbContext.Librarys.Remove(model);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Library> GetLibraryByIdAsync(Guid id)
        {
            return await _dbContext.Librarys.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<List<LibraryReadModel>> GetLibraryListAsync()
        {
            List<Library> query = await _dbContext.Librarys.ToListAsync();
            return _mapper.Map<List<LibraryReadModel>>(query);
        }

        public async Task UpdateAsync(LibraryUpdateModel model, Library currentModel)
        {
            currentModel.Name = model.Name;
            currentModel.PhoneNumber = model.PhoneNumber;
            currentModel.Website = model.Website;

            if (model.Catalogs.Count > 0)
            {
                currentModel.Catalogs = model.Catalogs;
            }

            if (model.Address is null)
            {
                currentModel.Address = currentModel.Address;
                currentModel.Address.LibraryId = currentModel.Id; 
            }
            else
            {
                Address address = currentModel.Address;
                AddressCreateModel addressModel = model.Address;

                address.Number = addressModel.Number;
                address.ZipCode = addressModel.ZipCode;
                address.Street = addressModel.Street;
                address.State = addressModel.State;
                address.City = addressModel.City;
            }

            _dbContext.Update(currentModel);
            await _dbContext.SaveChangesAsync();
        }

    }
}