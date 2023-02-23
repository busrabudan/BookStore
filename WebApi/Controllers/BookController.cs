using Microsoft.AspNetCore.Mvc;
using WebApi.DBOperations;

namespace WebApi.AddControllers{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase{

        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context){
            _context = context;
        }
 

        [HttpGet]
        public List<Book> GetBooks(){
            var bookList = _context.Books.OrderBy(book => book.Id).ToList<Book>();
            return bookList;
        }

         [HttpGet("{id}")]
        public Book GetById(int id){
            var book = _context.Books.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook){
            var book = _context.Books.SingleOrDefault(x => x.Title == newBook.Title);
            if(book is not null){
                return BadRequest();
            }
             _context.Books.Add(newBook);
             _context.SaveChanges();
             return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] Book updateBook){
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if(book is null){
                return BadRequest();
            }

            book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
            book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;
            book.PublisDate = updateBook.PublisDate != default ? updateBook.PublisDate : book.PublisDate;
            book.Title = updateBook.Title != default ? updateBook.Title: book.Title;
            
            
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if(book is null){
                return BadRequest();
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }

    }
}