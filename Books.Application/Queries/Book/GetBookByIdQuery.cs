using Books.Application.DTOs;
using MediatR;

namespace Books.Application.Queries.Book
{
    public class GetBookByIdQuery : IRequest<BookReadModel>
    {
        public Guid Id {get; set;}

        public GetBookByIdQuery(Guid id)
        {
            this.Id = id;
        }        
    }
}
