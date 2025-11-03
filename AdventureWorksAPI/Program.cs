using AdventureWorksAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

#region Docker
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
#endregion

#region Builder
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

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();
#endregion

#region App
var app = builder.Build();

app.UseCors("MyNextJSCORS");

app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdventureWorks API V1"); c.InjectStylesheet("/swagger-ui/SwaggerDark.css"); });
}

app.UseAuthorization();
app.MapControllers();

// Minimal API example
//app.MapGet("/person/GetPersonList", (IPersonService personService) =>
//{
//    var persons = personService.GetPersonsList();
//    return Results.Ok(persons);
//});
app.MapGraphQL();

app.Run();
#endregion