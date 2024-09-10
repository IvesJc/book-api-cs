using BookApi.Data;
using BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Services.Autor;

public class AutorService : IAutorInterface
{

    private readonly AppDbContext _context;

    public AutorService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseModel<List<AutorModel>>> getAllAutores()
    {
        ResponseModel<List<AutorModel>> response = new();
        try
        {
            var autores = await _context.Autores.ToListAsync();
            response.Dados = autores;
            response.Menssagem = "Todos os autores foram coletados";
            return response;
        }
        catch (Exception e)
        {
            response.Menssagem = e.Message;
            response.Status = false;
            return response;
        }
    }

    public Task<ResponseModel<AutorModel>> getAutorById(int idAutor)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseModel<AutorModel>> getAutorByIdLivro(int idLivro)
    {
        throw new NotImplementedException();
    }
}