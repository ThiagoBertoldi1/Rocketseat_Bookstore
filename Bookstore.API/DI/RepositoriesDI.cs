using Bookstore.Data.Repositories;
using Bookstore.Domain.Interfaces.Repositories;

namespace Bookstore.API.DI;

public static class RepositoriesDI
{
    public static void DIRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IBookRepository, BookRepository>();
        services.AddSingleton(provider => new BookRepository(configuration));
    }
}
