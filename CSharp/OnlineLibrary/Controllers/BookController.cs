using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Services;

namespace OnlineLibrary.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IEnumerable<Book> GetAll()
    {
        using var db = new OnlineLibraryContext(new DbContextOptions<OnlineLibraryContext>());

// Create
        Console.WriteLine("Inserting a new blog");
        db.Add(new Book() { Title = "http://blogs.msdn.com/adonet" });
        db.SaveChanges();

// Read
        Console.WriteLine("Querying for a blog");
        var blog = db.Books
            .OrderBy(b => b.Id)
            .First();

// Update
        Console.WriteLine("Updating the blog and adding a post");
        blog.Title = "https://devblogs.microsoft.com/dotnet";
        db.SaveChanges();

// Delete
        Console.WriteLine("Delete the blog");
        db.Remove(blog);
        db.SaveChanges();

        return null;
        //return _bookService.GetAllBooks();
    }
}