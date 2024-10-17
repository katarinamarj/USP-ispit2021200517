namespace Library.API.Services;

public interface IBookService
{
    Task<string> Get();
    Task<string> Create();
}