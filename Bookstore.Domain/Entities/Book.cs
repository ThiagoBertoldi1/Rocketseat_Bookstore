using Bookstore.Domain.Enums;

namespace Bookstore.Domain.Entities;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public GenderEnum Gender { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
}
