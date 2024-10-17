using Library.Application.Author.Queries;
using Library.Application.Common.Dto;
using MediatR;
using MongoDB.Driver;

namespace Library.Application.Author.Handlers;

public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<AuthorDto>>
{
    private readonly IMongoCollection<Domain.Entities.Author> _authors;

    public GetAllAuthorsQueryHandler(IMongoDatabase database)
    {
        _authors = database.GetCollection<Domain.Entities.Author>("Authors");
    }

    public async Task<List<AuthorDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _authors.Find(_ => true).ToListAsync();

        return authors.Select(a => new AuthorDto()
        {
            FirstName = a.FirstName,
            LastName = a.LastName
        }).ToList();
    }
}

