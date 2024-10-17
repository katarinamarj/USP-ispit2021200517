using Library.Application.Book.Queries;
using Library.Application.Common.Dto;
using MongoDB.Driver;
using MediatR;

namespace Library.Application.Book.Handlers;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<BookDto>>
{
    
    private readonly IMongoCollection<Domain.Entities.Book> _books;

    public GetBooksQueryHandler(IMongoDatabase database)
    {
        _books = database.GetCollection<Domain.Entities.Book>("Books");
    }
    public async Task<List<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _books.Find(_ => true).ToListAsync();

        return books.Select(b => new BookDto()
        {
            BookId = b.BookId,
            Name = b.Name,
            Description = b.Description,
            Genre = b.Genre
        }).ToList();
    }
}
