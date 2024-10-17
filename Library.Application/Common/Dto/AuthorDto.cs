namespace Library.Application.Common.Dto;

public record AuthorDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Id { get; set; }
}