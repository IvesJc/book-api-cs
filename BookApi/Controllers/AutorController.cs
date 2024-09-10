using BookApi.Controllers.Dto.Autor;
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
            var autores = await _autorInterface.GetAllAutores();
            return Ok(autores);
        }

        [HttpGet("getAutorById/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> GetAutorById(int idAutor)
        {
            var autor = await _autorInterface.GetAutorById(idAutor);
            return Ok(autor);
        }

        [HttpGet("getAutorByIdLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> GetAutorByIdLivro(int idLivro)
        {
            var autorByIdLivro = await _autorInterface.GetAutorByIdLivro(idLivro);
            return Ok(autorByIdLivro);
        }
        
        [HttpPost("createAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CreateAutor(AutorRequestCreateDto autorRequestCreateDto)
        {
            var newAutor = await _autorInterface.CreateAutor(autorRequestCreateDto);
            return Created(Uri.UriSchemeHttp, newAutor);
        }

        [HttpPut("updateAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> UpdateAutor(AutorRequestUpdateDto autorRequestUpdateDto)
        {
            var updatedAutor = await _autorInterface.UpdateAutor(autorRequestUpdateDto);
            return Created(Uri.UriSchemeHttp, updatedAutor);
        }

        [HttpDelete("deleteAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> DeleteAutorById(int idAutor)
        {
            await _autorInterface.DeleteAutor(idAutor);
            return NoContent();
        }
        
    }
}
