using Books.Application.Library.DTOs;
using MediatR;

namespace Books.Application.Library.Commands
{
    public class CreateLibraryCommand : IRequest<LibraryCreateModel>
    {
        public LibraryCreateModel values; 
        public CreateLibraryCommand(LibraryCreateModel model)
        {
            this.values = model;
        }
    }
}