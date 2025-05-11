using Bookstore.Domain.Entities;
using Bookstore.Domain.Requests.Books;

namespace Bookstore.Domain.Interfaces.Services;

public interface IBookService
{
    Task<bool> Create(CreateBookRequest book, CancellationToken cancellationToken);
    Task<bool> Update(Book book, CancellationToken cancellationToken);
    Task<bool> Delete(Guid book, CancellationToken cancellationToken);
    Task<Book?> GetById(Guid bookId, CancellationToken cancellationToken);
    Task<List<Book>> GetAll(CancellationToken cancellationToken);
}
