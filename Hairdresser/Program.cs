using Hairdresser.Context;
using Hairdresser.Entities;
using Hairdresser.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;  // DbContext'in bulunduğu namespace'i dahil edin


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



// PostgreSQL bağlantı dizesi
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");  // appsettings.json'dan alınabilir

// DbContext'i PostgreSQL ile yapılandırma
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));  // PostgreSQL kullanıyorsanız, Npgsql'u burada belirtiyoruz




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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");







//SeedData.Initialize(app);

app.Run();


