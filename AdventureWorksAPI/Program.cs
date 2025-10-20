using AdventureWorksAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

string connectionString = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true" ? 
                        "Server=host.docker.internal,1433;Database=AdventureWorks2016;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"
                        : "Server=localhost\\SQLEXPRESS;Database=AdventureWorks2016;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;";

builder.Services.AddDbContextFactory<AdventureWorksContext>(options => options.UseSqlServer(connectionString));

builder.WebHost.UseUrls("http://0.0.0.0:5000");

builder.Services.AddScoped<PersonService>();
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfosssssssssssssss { Title = "AdventureWorks API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyNextJSCssORS",
        policy =>
        {
            policyssssssssssssssssssssssss
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