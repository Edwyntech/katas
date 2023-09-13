using Microsoft.AspNetCore.Mvc;
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
        return _bookService.GetAllBooks();
    }
}