namespace Library.Application.Book.Commands;

using MediatR;

public record AddBookCommand : IRequest<int>
{
    public int BookId { get; set; }  

    public string Name { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
}