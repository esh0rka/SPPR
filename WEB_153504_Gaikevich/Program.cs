using WEB_153504_Gaikevich.Services.CategoryService;
using WEB_153504_Gaikevich.Services.AutoPartService;
using WEB_153504_Gaikevich.Data;
using WEB_153504_Gaikevich.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddDbContext<AutoPartContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AutoPartContext") ?? throw new InvalidOperationException("Connection string 'AutoPartContext' not found.")));

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategoryService, ApiCategoryService>();
builder.Services.AddScoped<IAutoPartService, ApiAutoPartService>();

var uriData = new UriData();
builder.Configuration.GetSection("UriData").Bind(uriData);
builder.Services.AddSingleton(uriData);

builder.Services.AddHttpClient<IAutoPartService, ApiAutoPartService>(opt => opt.BaseAddress = new Uri(uriData.ApiUri));
builder.Services.AddHttpClient<ICategoryService, ApiCategoryService>(opt => opt.BaseAddress = new Uri(uriData.ApiUri));

var app = builder.Build();

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
