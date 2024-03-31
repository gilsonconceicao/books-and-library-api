using AutoMapper;
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
    private readonly IMapper _mapper;
    public CreateLibraryHandler(DbContextPostgres context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<LibraryCreateModel> Handle(CreateLibraryCommand command, CancellationToken cancellationToken)
    {
        var library = command.values;

        var newLibrary = _mapper.Map<Books.Domain.Entities.Library>(library); 

        await _context.Librarys.AddAsync(newLibrary);
        await _context.SaveChangesAsync();
        return library;
    }
}
