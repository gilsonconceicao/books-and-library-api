using MediatR;

namespace Books.Application.Commands
{
    public class DeleteBookCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public DeleteBookCommand(Guid id)
        {
            Id = id;
        }
    }
}