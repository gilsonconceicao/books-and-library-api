using Books.Application.DTOs.Book;
using MediatR;

namespace Books.Application.Commands.Book;

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