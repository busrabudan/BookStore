using Microsoft.AspNetCore.Mvc;

namespace WebApi.AddControllers{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase{
        
        private static List<Book> BookList = new List<Book>(){
            new Book(){
                Id = 1,
                Title = "The Hobbit",
                GenreId = 1,
                PageCount = 295,
                PublisDate = new DateTime(1937, 9, 21)
            },
            new Book(){
                Id = 2,
                Title = "The Lord of the Rings",
                GenreId = 1,
                PageCount = 1216,
                PublisDate = new DateTime(1954, 7, 29)
            },
            new Book(){
                Id = 3,
                Title = "The Silmarillion",
                GenreId = 1,
                PageCount = 429,
                PublisDate = new DateTime(1977, 9, 15)
            },
        };

        [HttpGet]
        public List<Book> GetBooks(){
            var bookList = BookList.OrderBy(book => book.Id).ToList<Book>();
            return bookList;
        }

         [HttpGet("{id}")]
        public Book GetById(int id){
            var book = BookList.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook){
            var book = BookList.SingleOrDefault(x => x.Title == newBook.Title);
            if(book is not null){
                return BadRequest();
            }
             BookList.Add(newBook);
             return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] Book updateBook){
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if(book is null){
                return BadRequest();
            }

            book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
            book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;
            book.PublisDate = updateBook.PublisDate != default ? updateBook.PublisDate : book.PublisDate;
            book.Title = updateBook.Title != default ? updateBook.Title: book.Title;
            
            
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id){
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if(book is null){
                return BadRequest();
            }
            BookList.Remove(book);
            return Ok();
        }

    }
}