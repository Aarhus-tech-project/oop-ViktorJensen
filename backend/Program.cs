using backend.src.Models;
using backend.src.services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("ApiDatabase"));

var mongoSettings = builder.Configuration
    .GetSection("ApiDatabase")
    .Get<MongoDbSettings>();

var mongoClient = new MongoClient(mongoSettings!.ConnectionString);
var mongoDatabase = mongoClient.GetDatabase(mongoSettings.DatabaseName);

builder.Services.AddSingleton<IMongoClient>(mongoClient);
builder.Services.AddSingleton(mongoDatabase);

builder.Services.AddSingleton<StocksService>();
builder.Services.AddSingleton<PortfolioService>();
builder.Services.AddScoped<HoldingsService>();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddOpenApi();
builder.Services.AddOpenApiDocument();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapOpenApi();
app.UseOpenApi();
app.UseSwaggerUi();

app.UseAuthorization();

app.MapControllers();

app.Run();
