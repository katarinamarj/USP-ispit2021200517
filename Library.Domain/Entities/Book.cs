using MongoDB.Entities;

namespace Library.Domain.Entities;

public class Book : Entity
{
    public int BookId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
}