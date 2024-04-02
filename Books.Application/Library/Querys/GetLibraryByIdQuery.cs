using AutoMapper;
using Books.Application.Library.DTOs;
using Books.Infrastructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Books.Domain.Entities;
using Books.Application.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Books.Application.Queries.Library;

public class GetLibraryByIdQuery : IRequest<Books.Domain.Entities.Library>
{
    public Guid LibraryId { get; set; }
    public GetLibraryByIdQuery(Guid libraryId)
    {
        this.LibraryId = libraryId;
    }
}

public class GetLibraryByIdQueryHandler : IRequestHandler<GetLibraryByIdQuery, Books.Domain.Entities.Library>
{
    private readonly DbContextPostgres _context;
    public GetLibraryByIdQueryHandler(DbContextPostgres context, IMapper mapper)
    {
        _context = context;
    }

    public async Task<Books.Domain.Entities.Library> Handle(GetLibraryByIdQuery request, CancellationToken cancellationToken)
    {
        var listLibrary = await _context
            .Librarys
            .FirstOrDefaultAsync(c => c.Id == request.LibraryId)
            ?? throw new NotFoundException(new
            {
                Code = StatusCodes.Status404NotFound,
                ErrorMessage = $"Biblioteca não encontrada ou não existe."
            });

        return listLibrary;
    }
}
