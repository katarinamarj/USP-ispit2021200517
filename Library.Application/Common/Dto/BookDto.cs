namespace Library.Application.Common.Dto;

public record BookDto
{
    public int BookId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
}