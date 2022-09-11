using Microsoft.Extensions.Configuration;
using Wk.Application.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

Initializer.Configure(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
