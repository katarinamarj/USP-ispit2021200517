using Library.Application.Author.Commands;
using Library.Domain.Entities;
using MediatR;
using MongoDB.Driver;

public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, string>
{
    private readonly IMongoDatabase _database;

    public AddAuthorCommandHandler(IMongoDatabase database)
    {
        _database = database;
    }

    public async Task<string> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        var authorsCollection = _database.GetCollection<Author>("Authors");

        var author = new Author
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
        };

        await authorsCollection.InsertOneAsync(author, cancellationToken: cancellationToken);
        return "Author added successfully!";
    }
}