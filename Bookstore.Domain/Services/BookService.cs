using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces.Repositories;
using Bookstore.Domain.Interfaces.Services;
using Bookstore.Domain.Requests.Books;

namespace Bookstore.Domain.Services;
public class BookService(IBookRepository bookRepository) : IBookService
{
    private readonly IBookRepository _bookRepository = bookRepository;

    public async Task<bool> Create(CreateBookRequest book, CancellationToken cancellationToken)
    {
        var newBook = new Book
        {
            Id = Guid.NewGuid(),
            Title = book.Title,
            Price = book.Price,
            Amount = book.Amount,
            Author = book.Author,
            Gender = book.Gender
        };

        var inserted = await _bookRepository.InsertAsync(newBook, cancellationToken);

        return inserted;
    }

    public async Task<bool> Update(Book book, CancellationToken cancellationToken)
        => await _bookRepository.UpdateAsync(book, cancellationToken);

    public async Task<bool> Delete(Guid bookId, CancellationToken cancellationToken)
        => await _bookRepository.DeleteAsync(bookId, cancellationToken);

    public async Task<Book?> GetById(Guid bookId, CancellationToken cancellationToken)
        => await _bookRepository.GetByIdAsync(bookId, cancellationToken);

    public async Task<List<Book>> GetAll(CancellationToken cancellationToken)
        => await _bookRepository.GetAllAsync(cancellationToken);

}
