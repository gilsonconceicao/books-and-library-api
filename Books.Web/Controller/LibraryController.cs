using Books.Application.Commands.Library;
using Books.Application.DTOs.Library;
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
        public LibraryController(IMediator mediator)
        {
            _mediator = mediator;
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
            List<LibraryReadModel> query = await _mediator.Send(new GetLibraryListQuery());
            return Ok(query);
        }
    }
}