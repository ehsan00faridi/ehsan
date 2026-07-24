using Application.Features.Products.Query;
using Application.Interfaces;
using Application.Services.Sms;
using Domain.Models.Customers;
using Domain.Models.Ordera;
using Domain.Models.Products;
using Infrastructure.FileUploadservice;
using Infrastructure.Queries;
using Infrastructure.Queries.Products;
using Infrastructure.Redis;
using Infrastrucure.Email;
using Infrastrucure.Repository;
using Infrastrucure.Services.Sms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System.Data;

namespace Infrastrucure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services
            ,IConfiguration configuration) {

            services.AddDbContext<ApplicationDbContext>( option=>
            option.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.Configure<SmsSettings>(configuration.GetSection("Sms"));
            services.AddScoped<ISmsService, SmsService>();

            services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(
        sp.GetRequiredService<IConfiguration>()
        .GetConnectionString("ConnectionString")));

            //productlist
            services.AddScoped<IProductQueries, ProductQueries>();

            services.AddScoped<IProductById,ProductById>();

            services.Configure<EmailSettings>(configuration.GetSection("Email"));
            services.AddScoped<IEmailService, SmtpEmailService>();
            services.AddScoped<IOtpService, OtpService>();
            string redisConnectionString = configuration.GetConnectionString("RedisConnection");

            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var configuration = ConfigurationOptions.Parse(redisConnectionString, true);    

             
                configuration.AbortOnConnectFail = false;

                return ConnectionMultiplexer.Connect(configuration);
            });

            services.AddScoped<IFileUploadservice,FileUploadservice>();

            return services;

        }
    }
}
