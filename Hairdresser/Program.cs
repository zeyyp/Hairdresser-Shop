using Hairdresser.Context;
using Hairdresser.Entities;
using Hairdresser.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;  // DbContext'in bulundu�u namespace'i dahil edin


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



// PostgreSQL ba�lant� dizesi
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");  // appsettings.json'dan al�nabilir

// DbContext'i PostgreSQL ile yap�land�rma
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));  // PostgreSQL kullan�yorsan�z, Npgsql'u burada belirtiyoruz



builder.Services.AddIdentity<AppUser, Role>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.Run();
