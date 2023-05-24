using CompanyManager.Database;
using CompanyManager.Database.Entities;
using CompanyManager.Interfaces.ControllerInterfaces;
using CompanyManager.Seeder;
using CompanyManager.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<CompanyManagerContext>(options
                    => options.UseSqlServer(builder.Configuration["connectionString:DefaultConnection"]));

builder.Services.AddTransient(typeof(IBaseServiceInterface<>), typeof(BaseService<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
