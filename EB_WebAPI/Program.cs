using DomainServices;
using EB_EF;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
        .AddScoped<IMealBoxRepository, MealBoxEFRepository>()
        .AddScoped<IStudentRepository, StudentEFRepository>()
        .AddScoped<IEmployeeRepository, EmployeeEFRepository>()
        .AddScoped<IProductRepository, ProductEFRepository>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<EBDbContext>().AddDbContext<EBDbContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration["ConnectionStrings:Default"])
        .EnableSensitiveDataLogging(true);
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
