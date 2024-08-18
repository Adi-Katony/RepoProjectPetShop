using Microsoft.EntityFrameworkCore;
using ProjectPetShop.Repositories;
using ProjectPetShop.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IRepository, AnimalRepository>();  // Dependency Injection
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
builder.Services.AddDbContext<PetShopContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();
var app = builder.Build();
if (app.Environment.IsStaging() || app.Environment.IsProduction()) 
{
    app.UseExceptionHandler("/Error/Index");
}

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetShopContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");
app.Run();
