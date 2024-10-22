using MediatR;

namespace Library.Application.Author.Commands;

public record AddAuthorCommand() : IRequest<string>
{
    public string Id { get; set; }  
    public string FirstName { get; set; }
    public string LastName { get; set; }
}