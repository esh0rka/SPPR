using Microsoft.EntityFrameworkCore;
using WEB_153504_Gaikevich.API.Data;
using WEB_153504_Gaikevich.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");
string connectionString = builder.Configuration.GetConnectionString("Default") ?? "";

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(connectionString);
});

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAutoPartService, AutoPartService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

DbInitializer.SeedData(app).GetAwaiter().GetResult();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();

