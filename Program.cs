using BookingSystem;
using BookingSystem.Data;
using BookingSystem.Mapping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add the DbContext to the DI container
builder.Services.AddDbContext<BookingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookingConString")));

// Add AutoMapper (scans the assembly for profiles)
builder.Services.AddAutoMapper(typeof(BookingProfile));
// Add services
builder.Services.AddServices();

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
    pattern: "{controller=Booking}/{action=Index}/{id?}");

app.Run();
