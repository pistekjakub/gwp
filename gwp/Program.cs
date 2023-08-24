using gwp.Models.Database;
using gwp.Repositories;
using gwp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MockDatabase>();
builder.Services.AddSingleton<ICacheService, CacheService>();
builder.Services.AddScoped<ILobRepository, LobRepository>();
builder.Services.AddScoped<IAvgService, AvgService>();

var mockDatabase = new MockDatabase();

var records = File.ReadAllLines("gwpByCountry.csv")
    .Skip(1)
    .Select(Record.FromCsv)
    .ToList();
mockDatabase.Records.AddRange(records);

builder.Services.AddSingleton(mockDatabase);
builder.Services.AddMemoryCache();

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
