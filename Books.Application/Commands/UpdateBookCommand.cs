using Books.Application.DTOs;
using MediatR;

namespace Books.Application.Commands;

public class UpdateBookCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public UpdateBookCommand(
        Guid id,
        string name, 
        string description
    )
    {
        Id = id;
        Name = name;
        Description = description;
    }
}