using Library.Domain.Entities;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

namespace Library.Worker;

public class AuthorWorker : BackgroundService
{
    private readonly IMongoCollection<Author> _authorCollection;

    public AuthorWorker(IMongoDatabase database)
    {
        _authorCollection = database.GetCollection<Author>("Authors");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine("Worker is running...");
        
            await DoWorkAsync();

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            
        }
    }

    private async Task DoWorkAsync()
    {
        // Pronalazi sve autore u kolekciji
        var authors = await _authorCollection.Find(_ => true).ToListAsync();
    
        if (!authors.Any())
        {
            Console.WriteLine("No authors found.");
            return;
        }

        foreach (var author in authors)
        {
            Console.WriteLine($"Author: {author.FirstName} {author.LastName}");
        }
    }
}