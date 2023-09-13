using OnlineLibrary;
using OnlineLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookService, BookService>();

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

// var books = new List<Book>
// {
//     new Book { Id = 1, Author = "Orwell", Title = "1984"},
//     new Book { Id = 2, Author = "Rowling", Title = "Harry Potter and the Philosopher Stone"},
//     new Book { Id = 3, Author = "Tolkien", Title = "The Lord of the Rings"},
// };
//
// var customers = new List<Customer>
// {
//     new Customer { Id = 1, FirstName = "Jerome", LastName = "Cayrol"}
// };