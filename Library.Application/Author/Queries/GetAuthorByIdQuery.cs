using Library.Application.Common.Dto;
using MediatR;

namespace Library.Application.Author.Queries;

public class GetAuthorByIdQuery: IRequest<AuthorDto>
{
    public string Id { get; }

    public GetAuthorByIdQuery(string id)
    {
        Id = id;
    }
}