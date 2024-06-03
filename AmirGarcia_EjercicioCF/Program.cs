using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AmirGarcia_EjercicioCF.Data;
using AmirGarcia_EjercicioCF;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient("API Client", client =>
{
    client.BaseAddress = new Uri("https://localhost:7241/"); // Asegúrate de usar la URL correcta de tu API
});

builder.Services.AddDbContext<AmirGarcia_EjercicioCFContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AmirGarcia_EjercicioCFContext") ?? throw new InvalidOperationException("Connection string 'AmirGarcia_EjercicioCFContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// En Program.cs para .NET 5+:
builder.Services.AddHttpClient();
builder.Services.AddScoped<AGApiService>();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
