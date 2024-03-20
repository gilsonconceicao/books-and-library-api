using System.ComponentModel;
using Books.Application.Book.Commands;
using Books.Application.Book.DTOs;
using Books.Application.Exceptions;
using Books.Application.Validators;
using Books.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace Books.Infrastructure.Handlers.Book;

public class CreateBookHandler : IRequestHandler<CreateBookCommand, BookCreateModel>
{
    private readonly IBookRepository _bookRepository;
    private readonly ILibraryRepository _libraryRepository;
    public CreateBookHandler(IBookRepository bookRepository, ILibraryRepository libraryRepository)
    {
        _bookRepository = bookRepository;
        _libraryRepository = libraryRepository;
    }

    public async Task<BookCreateModel> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {
        var newBook = command.Values;
        var findLibraryById = await _libraryRepository.GetLibraryByIdAsync(command.LibraryId);
        
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

        await _bookRepository.CreateAsync(newBook);
        return newBook;
    }
}