using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Data.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => 
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/Denied";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("GraduatedOnly", policy => policy.RequireClaim("GraduationYear", "2010", "2012", "2015"));
});

builder.Services.AddScoped<IMoviesService, MoviesService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
