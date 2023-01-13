using EB_EF;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.AspNetCore;
using Microsoft.EntityFrameworkCore;
using DomainServices;
using EB_GraphQL.GraphQL;

var builder = WebApplication.CreateBuilder(args);

var ConnectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddScoped<EBDbContext>().AddDbContext<EBDbContext>(options => options.UseSqlServer(ConnectionString));

builder.Services.AddScoped<IStudentRepository, StudentEFRepository>();
builder.Services.AddScoped<IMealBoxRepository, MealBoxEFRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeEFRepository>();
builder.Services.AddScoped<IProductRepository, ProductEFRepository>();
builder.Services.AddScoped<StudentQuery>();
builder.Services.AddScoped<StudentMutation>();
builder.Services.AddScoped<MealBoxQuery>();
builder.Services.AddScoped<MealBoxMutation>();
builder.Services.AddScoped<EmployeeQuery>();
builder.Services.AddScoped<EmployeeMutation>();
builder.Services.AddScoped<ProductQuery>();
builder.Services.AddScoped<ProductMutation>();


builder.Services
    .AddGraphQLServer()
    .AddQueryType(q => q.Name("Query"))
    .AddMutationType(d => d.Name("Mutation"))
    .AddType<EmployeeQuery>()
    .AddType<MealBoxQuery>()
    .AddType<StudentQuery>()
    .AddType<ProductQuery>()
    .AddTypeExtension<StudentMutation>()
    .AddTypeExtension<ProductMutation>()
    .AddTypeExtension<EmployeeMutation>()
    .AddTypeExtension<MealBoxMutation>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UsePlayground(new PlaygroundOptions
    {
        QueryPath = "/api",
        Path = "/playground"
    });
}

app.MapGraphQL();
app.UseRouting();

app.Run();
