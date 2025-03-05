using AuthDomain;
using AuthDomain.Querys;
using AuthDomain.Querys.Object;
using Data;
using Microsoft.EntityFrameworkCore;
using ProductDomain;
using ProductDomain.Commands;
using ProductDomain.Commands.Object;
using ProductDomain.Querys;
using ProductDomain.Querys.Objects;
using Service;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
string? path = builder.Configuration.GetConnectionString("sql");
builder.Services.AddDbContext<Connection>(row => row.UseSqlServer(path));

builder.Services.AddScoped <IAuthRepository, AuthRepository>();

builder.Services.AddScoped <IQueryService<EntryDTO, User?>, AuthenticationQueryService>();
builder.Services.AddScoped <IQueryService<User, ClaimsPrincipal>, CreatePrincipleQueryService>();
builder.Services.AddScoped <IQueryService<RegistrationDTO, User>, RegistrationUserQueryService>();

builder.Services.AddScoped <IQueryService<SaveFiles, List<string>>, SaveFileOnWWWRoot>();
builder.Services.AddScoped <IQueryService<SaveFiles, List<string>>, SaveFileOnWWWRoot>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICommandService<AddProductDTO>, AddProductCommandService>();

builder.Services.AddScoped<IQueryService<SearchCardProduct, List<CardProductDTO>>, SearchCardProductQueryService>();



builder.Services.AddAuthentication("Cookies")
                .AddCookie("Cookies", option =>
                {
                    option.LoginPath = "/Account/Login";
                    option.AccessDeniedPath = "/Account/AccessDenied";
                });

builder.Services.AddAuthorization(option =>
                                  option.AddPolicy("Authorization",
                                                      policy => { policy.RequireClaim("role", "User"); }));

var app = builder.Build();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
