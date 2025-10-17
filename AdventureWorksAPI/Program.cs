using AdventureWorksAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<AdventureWorksContext>(options => 
    options.UseSqlServer(
        "Server=localhost\\SQLEXPRESS;Database=AdventureWorks2016;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"));

builder.Services.AddScoped<PersonService>();
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.Run();