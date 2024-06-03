using AmirGarcia_EjercicioCF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AGApiBurger.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AGApiBurgerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AGApiBurgerContext") ?? throw new InvalidOperationException("Connection string 'AGApiBurgerContext' not found.")));
builder.Services.AddDbContext<AmirGarcia_EjercicioCFContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AmirGarcia_EjercicioCFContext")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
