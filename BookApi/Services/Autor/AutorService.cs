using BookApi.Controllers.Dto.Autor;
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

    public async Task<ResponseModel<List<AutorModel>>> GetAllAutores()
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

    public async Task<ResponseModel<AutorModel>> GetAutorById(int idAutor)
    {
        ResponseModel<AutorModel> response = new();
        try
        {
            var autor = await _context.Autores.FindAsync(idAutor);
            if (autor == null)
            {
                response.Menssagem = "Nenhum registro localizado com esse ID";
                return response;
            }
            response.Dados = autor;
            response.Menssagem = "Autor localizado por ID";
            return response;
        }
        catch (Exception e)
        {
            response.Menssagem = e.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<AutorModel>> GetAutorByIdLivro(int idLivro)
    {
        ResponseModel<AutorModel> response = new();
        try
        {
            // Include : entrar dentro de Livros, para ter acesso as colunas
            var livro = await _context.Livros.
                Include(a => a.Autor).
                FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
            if (livro == null)
            {
                response.Menssagem = "Nenhum registro localizado com esse ID Livro";
                return response;
            }
            response.Dados = livro.Autor;
            response.Menssagem = "Autor localizado por ID do Livro";
            return response;
        }
        catch (Exception e)
        {
            response.Menssagem = e.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<List<AutorModel>>> CreateAutor(AutorRequestCreateDto autorRequestCreateDto)
    {
        ResponseModel<List<AutorModel>> response = new();
        try
        {
            var autor = new AutorModel()
            {
                Name = autorRequestCreateDto.Nome,
                Sobrenome = autorRequestCreateDto.Sobrenome
            };
            _context.Add(autor);
            await _context.SaveChangesAsync();
            response.Dados = await _context.Autores.ToListAsync();
            
            response.Menssagem = "Autor criado com sucesso!";
            return response;
        }
        catch (Exception e)
        {
            response.Menssagem = e.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<AutorModel>> UpdateAutor(AutorRequestUpdateDto autorRequestUpdateDto)
    {
        ResponseModel<AutorModel> response = new();
        try
        {
            var autorExiste = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == autorRequestUpdateDto.Id);
            if (autorExiste == null)
            {
                response.Menssagem = "Nenhum registro localizado com esse ID Livro";
                return response;
            }

            autorExiste.Name = autorRequestUpdateDto.Nome;
            autorExiste.Sobrenome = autorRequestUpdateDto.Sobrenome;

            _context.Update(autorExiste);
            await _context.SaveChangesAsync();

            response.Dados = autorExiste;
            response.Menssagem = "Autor editado com sucesso!";
            return response;

        }
        catch (Exception e)
        {
            response.Menssagem = e.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<AutorModel>> DeleteAutor(int idAutor)
    {
        ResponseModel<AutorModel> response = new();
        try
        {
            var autorById = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == idAutor);
            if (autorById == null)
            {
                response.Menssagem = "Nenhum registro localizado com esse ID Livro";
                return response;
            }

            _context.Remove(autorById);
            await _context.SaveChangesAsync();
            return response;
        }
        catch (Exception e)
        {
            response.Menssagem = e.Message;
            response.Status = false;
            return response;
        }
    }
}