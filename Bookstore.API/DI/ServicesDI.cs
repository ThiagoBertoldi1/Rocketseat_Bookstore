using Bookstore.Domain.Interfaces.Services;
using Bookstore.Domain.Services;

namespace Bookstore.API.DI;

public static class ServicesDI
{
    public static void DIServices(this IServiceCollection services)
    {
        services.AddTransient<IBookService, BookService>();
    }
}
