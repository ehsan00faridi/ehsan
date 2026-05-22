using Application;
using AppWebAPI.Filters;
using Hangfire;
using Infrastrucure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();


builder.Host.UseSerilog();


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
