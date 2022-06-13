using AutoMapper;
using BookAPI.BLL.AutoMapperDTO;
using BookAPI.BLL.Services;
using BookAPI.BLL.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookAPI.BLL
{
    public static class DependcyInjection
    {
        public static IServiceCollection AddBussiness(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #region Cofigure Mapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<AutoMapperDefaultProfile>();
            });
            var mapper = config.CreateMapper();
        
            #endregion

            return services;
        }
    }
}
