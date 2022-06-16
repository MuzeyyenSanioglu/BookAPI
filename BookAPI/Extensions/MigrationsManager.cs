using BookAPI.Domain.Data;
using BookAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Extensions
{
    public static class MigrationsManager
    {
        public static IHost MigrateDataBase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var bookContext = scope.ServiceProvider.GetRequiredService<BookContext>();

                    if (bookContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                        bookContext.Database.Migrate();
                    BookContextSeed.SeedAsync(bookContext).Wait();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return host;
        }
    }
}
