using Books.Application.Commands;
using Books.Application.Commands.Book;
using Books.Application.DTOs;
using Books.Application.Queries;
using Books.Application.Queries.Book;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Books.Web.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<List<BookReadModel>> GetAllBooksAsync([FromQuery] string? Name)
        {
            var booksList = await _mediator.Send(new GetBooksListQuery(Name));
            return booksList;
        }

        [HttpGet("{Id}")]
        public async Task<BookReadModel> GetAllBookByIdAsync(Guid Id )
        {
            var booksList = await _mediator.Send(new GetBookByIdQuery(Id));
            return booksList;
        }

        [HttpPost]
        public async Task<BookCreateModel> CreateBookAsync(BookCreateModel book)
        {
            return await _mediator.Send(new CreateBookCommand(
                book.Name,
                book.Description
            ));
        }
        
        [HttpPut("{Id}")]
        public async Task<BookUpdateModel> UpdateBookAsync(Guid Id, BookUpdateModel model)
        {
            await _mediator.Send(new UpdateBookCommand(
                Id,
                model.Name, 
                model.Description
            ));

            return model;
        }

        [HttpDelete("{Id}")]
        public async Task DeleteBookByIdAsync(Guid Id)
        {
            await _mediator.Send(new DeleteBookCommand(Id));
        }
    }
}