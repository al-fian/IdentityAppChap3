using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ProductDbContext>(opts => 
    opts.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddDbContext<IdentityDbContext>(opts =>
    opts.UseSqlite(builder.Configuration.GetConnectionString("IdentityConnection"),
    opts => opts.MigrationsAssembly("WebApp")));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<IdentityDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

app.Run();
