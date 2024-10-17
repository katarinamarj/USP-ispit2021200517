namespace Library.API.Services;

public class AuthorService : IAuthorService
{
    public async Task<string>Get() => "Katarina";

    public async Task<string> Create() => "Created!";
}

