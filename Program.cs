using BookingSystem.Data;
using BookingSystem.Mapping;
using BookingSystem.Repositories;
using BookingSystem.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add the DbContext to the DI container
builder.Services.AddDbContext<BookingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookingConString")));

// Register Repositories
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

// Register Services
builder.Services.AddScoped<IBookingService, BookingService>(); // Register BookingService

// Add AutoMapper (scans the assembly for profiles)
builder.Services.AddAutoMapper(typeof(BookingProfile));

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
