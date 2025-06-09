using System.Text;
using BroasterWebApp;
using BroasterWebApp.DataBase;
using BroasterWebApp.Entities;
using BroasterWebApp.interfaces;
using BroasterWebApp.repositories;
using BroasterWebApp.Components;
using BroasterWebApp.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

#region JWT Config & Cookies
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = jwtSettings["Key"];

/*
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});*/


builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/access-denied";
    });


#endregion

#region  DTContext Config
builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion

#region  DependencyInjection
builder.Services.AddHttpClient();

builder.Services.AddScoped<IRepository<Account>, AccountRepository>();
builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IRepository<Account>, AccountRepository>();
builder.Services.AddScoped<ProtectedLocalStorage>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IUserDomainService, UserDomainService>();
builder.Services.AddScoped<ITokenService, TokenService>();


builder.Services.AddControllers();
#endregion

//builder.Services.AddBlazoredSessionStorage();
builder.Services.AddHttpClient();

builder.Services.AddHttpClient("ServerAPI", client => 
{
    client.BaseAddress = new Uri(builder.Configuration["BaseUrl"]!);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});


var app = builder.Build();

app.UseAuthentication();  
app.UseAuthorization();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); 
app.UseAntiforgery();
app.MapControllers();
app.MapRazorComponents<App>() 
    .AddInteractiveServerRenderMode();

app.Run();
