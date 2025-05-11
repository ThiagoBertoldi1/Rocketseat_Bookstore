using Bookstore.Domain.Enums;

namespace Bookstore.Domain.Requests.Books;
public class CreateBookRequest
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public GenderEnum Gender { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
}
