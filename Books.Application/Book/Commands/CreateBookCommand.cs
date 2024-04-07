using AutoMapper;
using Books.Application.Book.DTOs;
using Books.Domain.Exceptions;
using Books.Application.Validators;
using Books.Infrastructure.Contexts;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Books.Application.Book.Commands;

public class CreateBookCommand : IRequest<BookCreateModel>
{
    public BookCreateModel Values { get; set; }
    public Guid LibraryId { get; set; }

    public CreateBookCommand(
        BookCreateModel model,
        Guid LibraryId
    )
    {
        this.Values = model;
        this.LibraryId = LibraryId;
    }
}
public class CreateBookHandler : IRequestHandler<CreateBookCommand, BookCreateModel>
{
    private readonly DbContextPostgres _context;
    private readonly IMapper _mapper;
    public CreateBookHandler(DbContextPostgres context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BookCreateModel> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {
        var newBook = command.Values;
        var findLibraryById = await _context.Librarys
            .Where(c => c.Id == command.LibraryId)
            .FirstOrDefaultAsync();


        if (findLibraryById is null)
        {
            throw new CustomException(StatusCodes.Status404NotFound, "Book", "Livro não encontrado ou não existe");
        }

        BookModelValidator validator = new BookModelValidator();
        ValidationResult result = validator.Validate(newBook);

        if (!result.IsValid)
        {
            var errorsMessage = new List<string>();
            foreach (var item in result.Errors)
            {
                errorsMessage.Add(item.ErrorMessage);
            }
            throw new CustomException(
                StatusCodes.Status400BadRequest,
                "Book",
                new
                {
                    Message = "Não foi possível validar os dados enviados",
                    Details = errorsMessage
                }
            );
        }


        var newBookToSave = new Domain.Entities.Book()
        {
            Name = newBook.Name,
            Description = newBook.Description,
            PublishingCompany = newBook.PublishingCompany,
            PublishYear = newBook.PublishYear,
            Language = newBook.Language,
            PageNumber = newBook.PageNumber,
            StatusAvailability = newBook.StatusAvailability,
            Format = newBook.Format,
            LibraryId = command.LibraryId,
            BookNumber = _context.Books.Count() + 1
        };

        await _context.Books.AddAsync(newBookToSave);
        await _context.SaveChangesAsync();
        return newBook;
    }
}
