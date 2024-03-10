using Microsoft.AspNetCore.Mvc;

namespace Books.Web.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        public BookController()
        {
            
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok("Todos os livros cadastrados");
        }
    }
}