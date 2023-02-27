using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookDetail{
    public class GetBookDetailQuery{
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public GetBookDetailQuery(BookStoreDbContext dbContext){
            _dbContext = dbContext;
        }

        public BookDetailViewModel Handle(){
            var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException("Kitap bulunamadı");
            BookDetailViewModel vm = new BookDetailViewModel();
            vm.Title = book.Title;
            vm.PageCount = book.PageCount.ToString();
            vm.PublishDate = book.PublisDate.Date.ToString("dd/MM/yyyy");
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            return vm;
        }

        public class BookDetailViewModel{
            public string Title { get; set; }
            public string Genre { get; set; }
            public string PageCount { get; set; }
            public string PublishDate { get; set; }
        }
    }
}