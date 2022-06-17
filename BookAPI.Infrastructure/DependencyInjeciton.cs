using BookAPI.DAL.Repository;
using BookAPI.DAL.Repository.Interfaces;
using BookAPI.Domain.Data;
using BookAPI.Infrastructure.Repositories;
using BookAPI.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAPI.Infrastructure
{
    public static class DependencyInjeciton
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookContext>(options =>
                       options.UseSqlServer(configuration.GetConnectionString("BookConnection"),
                       b => b.MigrationsAssembly(typeof(BookContext).Assembly.FullName)),
                       ServiceLifetime.Singleton);

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IBookrepository, BookRepository>();
            return services;

        }
    }
}
