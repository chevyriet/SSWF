using DomainServices;
using EB_EF;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adding Services to DI Container
builder.Services.AddControllersWithViews();
builder.Services
    .AddScoped<IMealBoxRepository, MealBoxEFRepository>()
    .AddScoped<IStudentRepository, StudentEFRepository>()
    .AddScoped<IEmployeeRepository, EmployeeEFRepository>()
    .AddScoped<IProductRepository, ProductEFRepository>()
    .AddScoped<EBSeedData>()
    .AddScoped<EBIdentitySeedData>()

    // EF DB
    .AddDbContext<EBDbContext>(opts =>
     {
         opts
             .UseSqlServer(builder.Configuration["ConnectionStrings:Default"])
             .EnableSensitiveDataLogging(true);
     })
    // Identity
    .AddDbContext<EBSecurityDbContext>(opts =>
    {
        opts
            .UseSqlServer(builder.Configuration["ConnectionStrings:Security"])
            .EnableSensitiveDataLogging(true);
    })
    .AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<EBSecurityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("OnlyEmployeeUsersAndUp", policy => policy
        .RequireAuthenticatedUser()
        .RequireClaim("UserType", "employeeuser"));

    options.AddPolicy("OnlyStudentUsersAndUp", policy => policy
        .RequireAuthenticatedUser()
        .RequireClaim("UserType", "studentuser", "employeeuser"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    //Seeding Database Trigger
    await SeedDatabase();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

// Seeding db
async Task SeedDatabase()
{
    using var scope = app.Services.CreateScope();
    var dbSeeder = scope.ServiceProvider.GetRequiredService<EBSeedData>();
    await dbSeeder.EnsurePopulated(true);

    var dbIdentitySeeder = scope.ServiceProvider.GetRequiredService<EBIdentitySeedData>();
    await dbIdentitySeeder.EnsurePopulated(true);
}
