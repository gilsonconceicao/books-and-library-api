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

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] LibraryCreateModel model)
        {
            await _mediator.Send(new CreateLibraryCommand(model));

            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLibrary()
        {
            var query = await _mediator.Send(new GetLibraryListQuery());
            var listMapped = _mapper.Map<List<GetLibraryListQueryDto>>(query);
            return Ok(listMapped);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            var query = await _mediator.Send(new GetLibraryByIdQuery(Id));
            var library = _mapper.Map<GetLibraryByIdQueryDto>(query);
            return Ok(library);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _mediator.Send(new DeleteLibraryCommand(Id));
            return NoContent();
        }
        [HttpGet("/Get/{ZipCode}")]
        public async Task<IActionResult> GetZipCode(string ZipCode)
        {
            GetZipCodeServices.GetZipCode(ZipCode);
            return NoContent();
        }
    }
}