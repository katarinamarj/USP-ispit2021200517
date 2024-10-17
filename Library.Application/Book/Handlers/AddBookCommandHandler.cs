using Library.Application.Book.Commands;
using MongoDB.Driver;
using MediatR;

namespace Library.Application.Book.Handlers;

public class AddBookCommandHandler : IRequestHandler<AddBookCommand, int>
{
    
    private readonly IMongoCollection<Domain.Entities.Book> _books;

    public AddBookCommandHandler(IMongoDatabase database)
    {
        _books = database.GetCollection<Domain.Entities.Book>("Books");
    }
    public async Task<int> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Domain.Entities.Book
        {
            BookId = request.BookId,
            Name = request.Name,
            Description = request.Description,
            Genre = request.Genre
        };
        
        await _books.InsertOneAsync(book, cancellationToken: cancellationToken);
        return book.BookId;
        
    }
}