using Books.Application.DTOs;
using MediatR;

namespace Books.Application.Commands.Book;

public class CreateBookCommand : IRequest<BookCreateModel>
{
    public string Name { get; set; }
    public string Description { get; set; }

    public CreateBookCommand(
        string name, 
        string description
    )
    {
        Name = name;
        Description = description;
    }
}