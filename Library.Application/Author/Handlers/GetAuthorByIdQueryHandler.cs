using Library.Application.Author.Queries;
using Library.Application.Common.Dto;
using MediatR;
using MongoDB.Driver;

namespace Library.Application.Author.Handlers;

public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDto>
{
    private readonly IMongoCollection<Domain.Entities.Author> _authors;

    public GetAuthorByIdQueryHandler(IMongoDatabase database)
    {
        _authors = database.GetCollection<Domain.Entities.Author>("Authors");
    }

    public async Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await _authors.Find(a => a.Id == request.Id).FirstOrDefaultAsync();

        if (author == null) return null;

        return new AuthorDto()
        {
            FirstName = author.FirstName,
            LastName = author.LastName
        };
    }
}