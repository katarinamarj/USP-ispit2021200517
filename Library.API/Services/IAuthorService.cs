namespace Library.API.Services;

public interface IAuthorService
{
    Task<string> Get();
    Task<string> Create();
}