using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces.Repositories;

public interface IBookRepository
{
    Task<bool> InsertAsync(Book book, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(Book book, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid bookId, CancellationToken cancellationToken);
    Task<Book?> GetByIdAsync(Guid bookId, CancellationToken cancellationToken);
    Task<List<Book>> GetAllAsync(CancellationToken cancellationToken);
}
