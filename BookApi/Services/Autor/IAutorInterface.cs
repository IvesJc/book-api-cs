using BookApi.Models;

namespace BookApi.Services.Autor;

public interface IAutorInterface
{
    // Task<>
    // async operation that returns a value
    Task<ResponseModel<List<AutorModel>>> getAllAutores();
    Task<ResponseModel<AutorModel>> getAutorById(int idAutor);
    Task<ResponseModel<AutorModel>> getAutorByIdLivro(int idLivro);
}