using BookApi.Models;
using BookApi.Services.Autor;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {

        private IAutorInterface _autorInterface;

        public AutorController(IAutorInterface @interface)
        {
            _autorInterface = @interface;
        }


        [HttpGet("getAllAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> GetAllAutores()
        {
            var autores = await _autorInterface.getAllAutores();
            return Ok(autores);
        }
        
    }
}
