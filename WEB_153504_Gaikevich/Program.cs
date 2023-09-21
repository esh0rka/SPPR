using WEB_153504_Gaikevich.Services.CategoryService;
using WEB_153504_Gaikevich.Services.AutoPartService;
using WEB_153504_Gaikevich.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AutoPartContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AutoPartContext") ?? throw new InvalidOperationException("Connection string 'AutoPartContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategoryService, MemoryCategoryService>();
builder.Services.AddScoped<IAutoPartService, MemoryAutoPartService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

