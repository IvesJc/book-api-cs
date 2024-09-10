namespace BookApi.Controllers.Dto.Autor;

public record AutorRequestCreateDto
{
    public string? Nome { get; set; }
    public string? Sobrenome { get; set; }
};