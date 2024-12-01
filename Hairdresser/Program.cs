using Hairdresser.Context;
using Microsoft.EntityFrameworkCore;  // DbContext'in bulunduðu namespace'i dahil edin


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



// PostgreSQL baðlantý dizesi
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");  // appsettings.json'dan alýnabilir

// DbContext'i PostgreSQL ile yapýlandýrma
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));  // PostgreSQL kullanýyorsanýz, Npgsql'u burada belirtiyoruz

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
