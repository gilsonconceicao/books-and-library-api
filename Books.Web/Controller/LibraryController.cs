using AutoMapper;
using AutoMapper.QueryableExtensions;
using Books.Application.Library.Commands;
using Books.Application.Library.DTOs;
using Books.Application.Queries.Library;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Books.Web.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public LibraryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona uma nova biblioteca
        /// </summary>
        /// <returns>Adiciona biblioteca</returns>
        /// <response code="200">200 Sucesso</response>
        /// <response code="400">400 Erro</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LibraryCreateModel))]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] LibraryCreateModel model)
        {
            await _mediator.Send(new CreateLibraryCommand(model));

            return Created();
        }

        /// <summary>
        /// Obtem todas as bibliotecas 
        /// </summary>
        /// <returns>Lista de bibliotecas</returns>
        /// <response code="200">200 Sucesso</response>
        /// <response code="400">400 Erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetLibraryListQueryDto>))]
        [HttpGet]
        public async Task<IActionResult> GetAllLibrary()
        {
            var query = await _mediator.Send(new GetLibraryListQuery());
            var listMapped = _mapper.Map<List<GetLibraryListQueryDto>>(query);
            return Ok(listMapped);
        }

        /// <summary>
        /// Obtem uma biblioteca específica por identificador
        /// </summary>
        /// <returns>Obtem uma bibliotecas</returns>
        /// <response code="200">200 Sucesso</response>
        /// <response code="400">400 Erro</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetLibraryByIdQueryDto))]
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            var query = await _mediator.Send(new GetLibraryByIdQuery(Id));
            var library = _mapper.Map<GetLibraryByIdQueryDto>(query);
            return Ok(library);
        }

        /// <summary>
        /// Remove uma biblioteca da base
        /// </summary>
        /// <returns>Ação de exclusão</returns>
        /// <response code="200">200 Sucesso</response>
        /// <response code="400">400 Erro</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _mediator.Send(new DeleteLibraryCommand(Id));
            return NoContent();
        }
    }
}