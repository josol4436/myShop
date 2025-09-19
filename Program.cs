using Microsoft.EntityFrameworkCore;
using MyShop.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// TODO: add DbContext configuration here if using EF Core database
builder.Services.AddDbContext<ItemDbContext>(options =>
{
    options.UseSqlite(
        builder.Configuration["ConnectionStrings:ItemDbContextConnection"]);
});

builder.Services.AddScoped<IItemRepository, ItemRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    DBInit.Seed(app);
}

/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/

app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();
