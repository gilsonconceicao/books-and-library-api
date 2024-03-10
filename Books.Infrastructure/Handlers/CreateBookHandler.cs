using Books.Application.Commands;
using Books.Application.DTOs;
using Books.Domain.Interfaces;
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

        await _bookRepository.CreateAsync(newBook); 
        return newBook; 
    }
}