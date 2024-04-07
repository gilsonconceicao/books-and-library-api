using Books.Domain.Exceptions;
using Books.Infrastructure.Contexts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Books.Application.Library.Commands;

public class DeleteLibraryCommand : IRequest<Guid>
{
    public Guid LibraryId { get; set; }
    public DeleteLibraryCommand(Guid libraryId)
    {
        this.LibraryId = libraryId;
    }
}

public class DeleteLibraryCommandHandler : IRequestHandler<DeleteLibraryCommand, Guid>
{
    public DbContextPostgres _dbContext { get; set; }
    public DeleteLibraryCommandHandler(DbContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(DeleteLibraryCommand request, CancellationToken cancellationToken)
    {
        var findLibrary = await _dbContext
            .Librarys
            .FirstOrDefaultAsync(c => c.Id == request.LibraryId) 
            ?? throw new CustomException(
                    StatusCodes.Status404NotFound, 
                    "Library", 
                    new 
                    {
                        Message = "Biblioteca não encontrada ou não existe"
                    });

        _dbContext.Librarys.Remove(findLibrary); 
        await _dbContext.SaveChangesAsync();
        return findLibrary.Id;
    }
}