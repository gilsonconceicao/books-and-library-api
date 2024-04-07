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

        /// <summary>
        /// Obtem todos os livros 
        /// </summary>
        /// <returns>List de livros </returns>
        /// <response code="200">200 Sucesso</response>
        /// <response code="400">400 Erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetBookListDto>))]
        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync([FromQuery] string? Name,
            string? Description, string? PublishYear, string? LibraryName)
        {
            var booksList = await _mediator.Send(
                new GetBooksListQuery(
                    name: Name,
                    description: Description,
                    publishYear: PublishYear,
                    libraryName: LibraryName
                )
            );

            var result = _mapper.Map<List<GetBookListDto>>(booksList);
            return Ok(result);
        }

        /// <summary>
        /// Obtem um livro específico por identificador
        /// </summary>
        /// <returns>Livro</returns>
        /// <response code="200">200 Sucesso</response>
        /// <response code="400">400 Erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBookByIdDto))]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAllBookByIdAsync(Guid Id)
        {
            var model = await _mediator.Send(new GetBookByIdQuery(Id));
            var result = _mapper.Map<GetBookByIdDto>(model);
            return Ok(result);
        }

        /// <summary>
        /// Adiciona um novo livro 
        /// </summary>
        /// <returns>Adiciona livro</returns>
        /// <response code="200">200 Sucesso</response>
        /// <response code="400">400 Erro</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(BookCreateModel))]
        [HttpPost("{LibraryId}")]
        public async Task<IActionResult> CreateBookAsync(Guid LibraryId, BookCreateModel book)
        {
            await _mediator.Send(new CreateBookCommand(book, LibraryId));

            return Created();
        }

        /// <summary>
        /// Atualiza as informações de um livro existente
        /// </summary>
        /// <returns>Atualiza o livro</returns>
        /// <response code="200">200 Sucesso</response>
        /// <response code="400">400 Erro</response>
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(BookUpdateModel))]
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateBookAsync(Guid Id, [FromBody] BookUpdateModel model)
        {
            await _mediator.Send(new UpdateBookCommand(
                Id,
                values: model
            ));

            return NoContent();
        }

        /// <summary>
        /// Remove um livro da base 
        /// </summary>
        /// <returns>Ação de exclusão</returns>
        /// <response code="200">200 Sucesso</response>
        /// <response code="400">400 Erro</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteBookByIdAsync(Guid Id)
        {
            await _mediator.Send(new DeleteBookCommand(Id));

            return NoContent();
        }
    }
}