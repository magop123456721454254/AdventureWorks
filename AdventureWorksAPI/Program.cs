using AdventureWorksAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// TEST COMMENT FOR FIRST PR

builder.Services.AddDbContextFactory<AdventureWorksContext>(options =>
    options.UseSqlServer(
        "Server=localhost\\SQLEXPRESS;Database=AdventureWorks2016;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"));

builder.WebHost.UseUrls("http://localhost:5000");

builder.Services.AddScoped<PersonService>();
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdventureWorks API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyNextJSCORS",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("MyNextJSCORS");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdventureWorks API V1"));
}

app.UseAuthorization();
app.MapControllers();

app.Run();