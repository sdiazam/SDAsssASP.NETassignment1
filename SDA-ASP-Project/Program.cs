using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SDA_ASP_Project.Data;
using Microsoft.Extensions.DependencyInjection;
using SDA_ASP_Project.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SDA_ASP_ProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SDA_ASP_ProjectContext") ?? throw new InvalidOperationException("Connection string 'SDA_ASP_ProjectContext' not found.")));

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();
/*
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedMangaData.Initialize(services);
}
*/
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
