using BookApi.Controllers.Dto.Autor;
using BookApi.Models;

namespace BookApi.Services.Autor;

public interface IAutorInterface
{
    // Task<>
    // async operation that returns a value
    Task<ResponseModel<List<AutorModel>>> GetAllAutores();
    Task<ResponseModel<AutorModel>> GetAutorById(int idAutor);
    Task<ResponseModel<AutorModel>> GetAutorByIdLivro(int idLivro);
    Task<ResponseModel<List<AutorModel>>> CreateAutor(AutorRequestCreateDto autorRequestCreateDto);
    Task<ResponseModel<AutorModel>> UpdateAutor(AutorRequestUpdateDto autorRequestUpdateDto);
    Task<ResponseModel<AutorModel>> DeleteAutor(int idAutor);
}