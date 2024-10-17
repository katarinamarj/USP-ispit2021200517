using FluentValidation.AspNetCore;
using Library.API.Filters;
using Library.Application.Book.Handlers;
using Library.Application.Common.Validators;
using Library.Worker;
using MediatR;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// konfiguracija iz appsettings.json
var mongoDbConfig = builder.Configuration.GetSection("MongoDbConfiguration");
string dbString = mongoDbConfig["DbString"]; 
string dbName = mongoDbConfig["DbName"];     

if (string.IsNullOrEmpty(dbString) || string.IsNullOrEmpty(dbName))
{
    throw new ArgumentNullException("Connection string or database name is not set in configuration.");
}

// MongoDb client
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(dbString));
builder.Services.AddSingleton(s => s.GetRequiredService<IMongoClient>().GetDatabase(dbName));

// MediatR
builder.Services.AddMediatR(typeof(AddBookCommandHandler).Assembly);

// workeri
builder.Services.AddHostedService<AuthorWorker>();


// kontroleri
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilter>();  //  ApiExceptionFilter 
})
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddAuthorCommandValidator>()); //fluent validacoja


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program{}
