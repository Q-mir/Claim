using AuthDomain;
using AuthDomain.Querys;
using AuthDomain.Querys.Object;
using Data;
using Microsoft.EntityFrameworkCore;
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

builder.Services.AddAuthentication("Cookies")
                .AddCookie("Cookies", option =>
                {
                    option.LoginPath = "/Account/Login";
                    option.AccessDeniedPath = "/Account/AccessDenied";
                });

builder.Services.AddAuthorization(option =>
                                  option.AddPolicy("Authorization",
                                                      policy => { policy.RequireClaim("rule", "User"); }));

var app = builder.Build();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();
app.UseAuthentication();
app.MapRazorPages();
app.Run();
