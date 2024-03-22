using AutoMapper;
using Books.Application.Book.DTOs;
using Books.Application.Exceptions;
using Books.Application.Validators;
using Books.Infrastructure.Contexts;
using FluentValidation.Results;
using MediatR;
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
            throw new NotFoundException("Não foi possível encontrar a biblioteca informada");
        }

        BookModelValidator validator = new BookModelValidator();
        ValidationResult result = validator.Validate(newBook);

        if (!result.IsValid)
        {
            var errorsMessage = new List<ErrorMessage>();
            foreach (var item in result.Errors)
            {
                errorsMessage.Add(new ErrorMessage { Message = item.ErrorMessage });
            }
            throw new BadRequestException(
                "Houve um erro",
                new CustomException(
                  code: "INVALID_FIELD",
                  message: "Não foi possível validar os dados enviados",
                  details: errorsMessage
              )
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
        };

        await _context.Books.AddAsync(newBookToSave);
        return newBook;
    }
}
