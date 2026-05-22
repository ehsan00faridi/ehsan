using Application.Features.Products.Query;
using Application.Interfaces;
using Application.Services.Sms;
using Domain.Models.Customers;
using Domain.Models.Ordera;
using Domain.Models.Products;
using Infrastructure.Queries;
using Infrastrucure.Email;
using Infrastrucure.Repository;
using Infrastrucure.Services.Sms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            services.AddScoped<IProductQueries, ProductQueries>();



            services.Configure<EmailSettings>(configuration.GetSection("Email"));
            services.AddScoped<IEmailService, SmtpEmailService>();



            return services;

        }
    }
}
