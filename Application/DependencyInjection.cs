using Application.Behaviors;
using Application.Features.Products.Command.Validation;
using Application.Services.CurrentUser;
using Application.Services.Sms;
using FluentValidation;
using Hangfire;
using Hangfire.SqlServer;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services ,IConfiguration configuration) {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PresetBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<ICurrentUserServices, CurrentUserServices>();
            services.AddValidatorsFromAssemblyContaining(typeof(AddProductValidator));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddHangfire(config => config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170).UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
            {
                CommandBatchMaxTimeout= TimeSpan.FromSeconds(5),
                SlidingInvisibilityTimeout= TimeSpan.FromMinutes(5),
                QueuePollInterval= TimeSpan.Zero,
                UseRecommendedIsolationLevel= true,
                UsePageLocksOnDequeue= true,
                DisableGlobalLocks= true,

            }));
            services.AddHangfireServer();
            

            return services;
        }
    }
}
