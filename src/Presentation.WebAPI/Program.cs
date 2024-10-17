using Core.Application.Extensions;
using Core.QueryContract.Extensions;
using Infrastructure.EfcDmPersistence.Extensions;
using Infrastructure.EfcQueries.Extensions;
using Microsoft.OpenApi.Models;
using VEA.Core.Domain;
using VEA.Core.Tools.ObjectMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "VEA.Presentation.WebAPI", Version = "v1" });
    c.CustomSchemaIds(type => type.FullName?.Replace("+", "_"));
});

builder.Services.AddControllers();

builder.Services.RegisterCoreServices();
string databasePath = Path.Combine(
    Directory.GetCurrentDirectory(),
    "..",
    "..",
    "Infrastructure",
    "VEA.Infrastructure.EfcDmPersistence",
    "VEADatabaseProduction.db"
);

string connectionString = $"Data Source={databasePath}";
builder.Services.RegisterPersistence(connectionString);
builder.Services.RegisterCommandHandlers();
builder.Services.RegisterCommandDispatcher();
builder.Services.RegisterQueryHandlers(connectionString);
builder.Services.RegisterQueryDispatcher();

builder.Services.AddScoped<IMapper, ObjectMapper>();

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();