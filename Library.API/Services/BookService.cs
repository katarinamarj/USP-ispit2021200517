namespace Library.API.Services;

public class BookService : IBookService
{
    public async Task<string>Get() => "Katarina";

    public async Task<string> Create() => "Created!";
}