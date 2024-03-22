using Books.Application.Library.DTOs;
using Books.Infrastructure.Contexts;
using MediatR;

namespace Books.Application.Library.Commands;

public class CreateLibraryCommand : IRequest<LibraryCreateModel>
{
    public LibraryCreateModel values;
    public CreateLibraryCommand(LibraryCreateModel model)
    {
        this.values = model;
    }
}

public class CreateLibraryHandler : IRequestHandler<CreateLibraryCommand, LibraryCreateModel>
{
    private readonly DbContextPostgres _context;
    public CreateLibraryHandler(DbContextPostgres context)
    {
        _context = context;
    }
    public async Task<LibraryCreateModel> Handle(CreateLibraryCommand command, CancellationToken cancellationToken)
    {
        var library = command.values;

        var libraryEntity = new Books.Domain.Entities.Library()
        {
            Name = library.Name,
            Email = library.Email,
            PhoneNumber = library.PhoneNumber,
            Website = library.Website,
            PhotoUrl = library.PhotoUrl,
            Catalogs = library.Catalogs,
            Address = {
                City = library.Address.City, 
                State = library.Address.State, 
                Street = library.Address.Street, 
                ZipCode = library.Address.ZipCode
            }
        };

        await _context.Librarys.AddAsync(libraryEntity);

        return library;
    }
}
