using AutoMapper;
using AutoMapper.QueryableExtensions;
using Books.Application.Book.Commands;
using Books.Application.Book.DTOs;
using Books.Application.Book.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Books.Web.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BookController(IMediator mediator,
            IMapper mapper)
        {
            this._mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync([FromQuery] string? name)
        {
            var booksList = await _mediator.Send(
                new GetBooksListQuery(name)
            );

            var result = _mapper.Map<List<GetBookListDto>>(booksList);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAllBookByIdAsync(Guid Id)
        {
            var model = await _mediator.Send(new GetBookByIdQuery(Id));
            var result = _mapper.Map<GetBookByIdDto>(model);
            return Ok(result);
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