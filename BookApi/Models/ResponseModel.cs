namespace BookApi.Models;

public class ResponseModel<T>
{
    public T? Dados { get; set; }
    public string Menssagem { get; set; } = string.Empty;
    public bool Status { get; set; } = true;
}