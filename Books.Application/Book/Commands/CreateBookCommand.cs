using Books.Application.Book.DTOs;
using MediatR;

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