using CodingChallengeEndava.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.ConfigureServices();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureCaching();
builder.Services.AddHttpClients(builder);
builder.Services.ConfigureVersioning();
builder.Services.ConfigureQuartz();

builder.ConfigureDbContext();

var app = builder.Build();
app.AddMigrationsToDatabase();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program { }