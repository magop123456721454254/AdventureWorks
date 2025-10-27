using System;
using AdventureWorksAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

bool runningInDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true"; // ? "host.docker.internal,1433" : "localhost\\SQLEXPRESS";

string connectionString;

if (runningInDocker)
{
    connectionString = builder.Configuration.GetConnectionString("AdventureWorksConnection") ?? "";
}
else
{
    connectionString = "Server=localhost\\SQLEXPRESS;Database=AdventureWorks2016;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;";
}

builder.Services.AddDbContextFactory<AdventureWorksContext>(options =>
    options.UseSqlServer(connectionString));

//bool runningInDocker = string.Equals(
//    global::System.Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER"),
//    "true",
//    StringComparison.OrdinalIgnoreCase
//);

Console.WriteLine($"[DEBUG] The server string used is: {connectionString}");
Console.WriteLine($"[DEBUG] Running in Docker container is: {runningInDocker}");

builder.Services.AddDbContextFactory<AdventureWorksContext>(options => options.UseSqlServer(connectionString));

builder.WebHost.UseUrls("http://0.0.0.0:5000");

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddOpenApi();
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyNextJSCORS",
        policy =>
        {
            policy
                 .WithOrigins(
                    "http://localhost:3000",   // what your browser uses
                    "http://frontend:3000"     // optional, for container-to-container requests
                )
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdventureWorks API", Version = "v1" });
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