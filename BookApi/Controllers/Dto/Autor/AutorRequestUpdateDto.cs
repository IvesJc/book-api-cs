namespace BookApi.Controllers.Dto.Autor;

public record AutorRequestUpdateDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    
}