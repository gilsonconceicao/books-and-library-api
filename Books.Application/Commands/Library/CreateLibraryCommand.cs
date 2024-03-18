using Books.Application.DTOs.Library;
using MediatR;

namespace Books.Application.Commands.Library
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