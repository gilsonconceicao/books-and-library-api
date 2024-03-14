using Books.Application.Commands.Book;
using Books.Application.DTOs;
using Books.Application.Exceptions;
using Books.Application.Validators;
using Books.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace Books.Infrastructure.Handlers;

public class CreateBookHandler : IRequestHandler<CreateBookCommand, BookCreateModel>
{
    private readonly IBookRepository _bookRepository;
    public CreateBookHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<BookCreateModel> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {
        var newBook = new BookCreateModel()
        {
            Description = command.Description,
            Name = command.Name
        };

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

        await _bookRepository.CreateAsync(newBook);
        return newBook;
    }
}