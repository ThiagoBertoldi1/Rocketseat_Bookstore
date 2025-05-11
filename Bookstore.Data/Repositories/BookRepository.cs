using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Bookstore.Data.Repositories;

public class BookRepository(IConfiguration configuration) : IBookRepository
{
    private readonly string _connString = configuration.GetConnectionString("DB")!;

    public async Task<bool> InsertAsync(Book book, CancellationToken cancellationToken)
    {
        var sql = @"INSERT INTO Book (Id, Title, Author, Gender, Price, Amount)
                    VALUES (@Id, @Title, @Author, @Gender, @Price, @Amount)";

        using var conn = new SqlConnection(_connString);
        await conn.OpenAsync(cancellationToken);
        return (await conn.ExecuteAsync(sql, book)) == 1;
    }

    public async Task<bool> UpdateAsync(Book book, CancellationToken cancellationToken)
    {
        var sql = @"UPDATE Book
                    SET Title = @Title, Author = @Author, Gender = @Gender,
                        Price = @Price, Amount = @Amount
                    WHERE Id = @Id";

        using var conn = new SqlConnection(_connString);
        await conn.OpenAsync(cancellationToken);
        return (await conn.ExecuteAsync(sql, book)) == 1;
    }

    public async Task<bool> DeleteAsync(Guid bookId, CancellationToken cancellationToken)
    {
        var sql = "DELETE FROM Book WHERE Id = @BookId";

        using var conn = new SqlConnection(_connString);
        await conn.OpenAsync(cancellationToken);
        return (await conn.ExecuteAsync(sql, new { BookId = bookId })) == 1;
    }

    public async Task<List<Book>> GetAllAsync(CancellationToken cancellationToken)
    {
        var sql = "SELECT * FROM Book";

        using var conn = new SqlConnection(_connString);
        await conn.OpenAsync(cancellationToken);
        return [.. await conn.QueryAsync<Book>(sql)];
    }

    public async Task<Book?> GetByIdAsync(Guid bookId, CancellationToken cancellationToken)
    {
        var sql = "SELECT * FROM Book WHERE Id = @BookId";

        using var conn = new SqlConnection(_connString);
        await conn.OpenAsync(cancellationToken);
        return await conn.QueryFirstOrDefaultAsync<Book>(sql, new { BookId = bookId });
    }
}
