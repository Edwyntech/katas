using Microsoft.EntityFrameworkCore;

namespace OnlineLibrary;

public class OnlineLibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public OnlineLibraryContext(DbContextOptions<OnlineLibraryContext> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("AppDb");
        optionsBuilder.UseSqlServer(connectionString);
    }
}