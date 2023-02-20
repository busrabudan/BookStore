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
            var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();
            return bookList;
        }

    }
}