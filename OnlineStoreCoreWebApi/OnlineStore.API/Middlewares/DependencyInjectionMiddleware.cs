using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineStore.Business.Contracts;
using OnlineStore.Business.Services;
using OnlineStore.Data.Contracts;
using OnlineStore.Data.Dapper;
using OnlineStore.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.API.Middlewares
{
    public static class DependencyInjectionMiddleware
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();

            //services.AddScoped<IProductRepository, EFProductRepository>();
            //services.AddScoped<ICategoryRepository, EFCategoryRepository>();
            //services.AddScoped<IUserRespository, EFUserRepository>();

            services.AddScoped<IProductRepository, DapperProductRepository>();
            services.AddScoped<ICategoryRepository, DapperCategoryRepository>();
            services.AddScoped<IUserRespository, DapperUserRepository>();

            services.AddScoped<DbContext, OnlineStoreContext>();

            return services;
        }
    }
}
