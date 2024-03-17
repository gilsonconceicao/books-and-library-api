using Books.Application.Commands;
using Books.Application.Commands.Book;
using Books.Application.DTOs.Book;
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
        public async Task<IActionResult> GetAllBooksAsync([FromQuery] string? Name)
        {
            var booksList = await _mediator.Send(new GetBooksListQuery(Name));
            return Ok(booksList);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAllBookByIdAsync(Guid Id )
        {
            var model = await _mediator.Send(new GetBookByIdQuery(Id));
            return Ok(model);
        }

        [HttpPost("{LibraryId}")]
        public async Task<IActionResult> CreateBookAsync(Guid LibraryId, BookCreateModel book)
        {
            await _mediator.Send(new CreateBookCommand(book, LibraryId));

            return Created();
        }
        
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateBookAsync(Guid Id, BookUpdateModel model)
        {
            await _mediator.Send(new UpdateBookCommand(
                Id,
                model.Name, 
                model.Description
            ));

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBookByIdAsync(Guid Id)
        {
            await _mediator.Send(new DeleteBookCommand(Id));

            return NoContent();
        }
    }
}