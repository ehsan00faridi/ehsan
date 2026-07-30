using Application;
using Domain.Models.User;
using Infrastrucure;
using Microsoft.AspNetCore.Identity;
using Serilog;

using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();


builder.Host.UseSerilog();



builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "WebAPI",
            ValidAudience = "WebAPI",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("YourSuperSecretKey-WebApi-sadfdgadc@!wrrrrrrrrrrrrrre"))
        };
    });

builder.Services.AddAuthorization();


builder.Services.AddIdentity<User, Domain.Models.Roles.Role>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
    builder.Services.Configure<IdentityOptions>(option => {
    option.Password.RequireDigit = true;
    option.Password.RequireLowercase = true;
    option.Password.RequireUppercase = true;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequiredLength = 8;
    option.User.RequireUniqueEmail = true;

        //option.SignIn.RequireConfirmedPhoneNumber = true;
        //option.SignIn.RequireConfirmedEmail = false;
        //option.SignIn.RequireConfirmedAccount = true;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanEditPolicy", policy =>
        policy.RequireClaim("Permission", "CanEdit"));
});




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);


builder.Services.AddApplication(builder.Configuration);

builder.Services.AddHttpContextAccessor();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
//app.UseAuthentication();


app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
