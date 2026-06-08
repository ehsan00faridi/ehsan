using Application;
using Application.Services.Sms;
using AppWebAPI.Filters;
using Domain.Models.Roles;
using Domain.Models.User;
using Hangfire;
using Infrastrucure;
using Infrastrucure.Services.Sms;
using Microsoft.AspNetCore.Identity;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();


builder.Host.UseSerilog();

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.Configure<IdentityOptions>(option => {
    option.Password.RequireDigit = true;
    option.Password.RequireLowercase = true;
    option.Password.RequireUppercase = true;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequiredLength = 8;
    option.User.RequireUniqueEmail = true;
    option.SignIn.RequireConfirmedPhoneNumber = true;
    option.SignIn.RequireConfirmedAccount = true;
});
//dotnet remove package Serilog


builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomActionFilter>();
    options.Filters.Add<CustomExceptionFilter>();

});




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);


builder.Services.AddApplication(builder.Configuration);

//builder.Services.AddScoped<ISmsService, SmsService>();

builder.Services.AddHttpContextAccessor();




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseHangfireDashboard();

app.MapControllers();

app.Run();
