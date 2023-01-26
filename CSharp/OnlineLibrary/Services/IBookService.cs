namespace OnlineLibrary.Services;

public interface IBookService
{
    IEnumerable<Book> GetAllBooks();
    Book GetBookById(int id);
    Book GetBookByTitle(string title);

    void AddBook(Book book);
    void RemoveBook(Book book);
}