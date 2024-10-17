using Library.Application.Common.Dto;
using MediatR;

namespace Library.Application.Author.Queries;

public class GetAllAuthorsQuery : IRequest<List<AuthorDto>>
{
    
}