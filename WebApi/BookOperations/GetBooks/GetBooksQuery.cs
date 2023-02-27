using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks{

    public class GetBooksQuery{

        private readonly BookStoreDbContext _dbContext;

        public GetBooksQuery(BookStoreDbContext dbContext){
            _dbContext = dbContext;
        }

        public List<Book> Handle(){
            var bookList = _dbContext.Books.OrderBy(book => book.Id).ToList<Book>();
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach(var book in bookList){
                vm.Add(new BooksViewModel{
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublisDate = book.PublisDate.Date.ToString("dd/MM/yyyy"),
                });
            }
            return bookList;
        }
    }

    public class BooksViewModel{
        public string ? Title { get; set; }
        public int PageCount { get; set; }
        public string ? PublisDate { get; set; }
        public string ? Genre { get; set; }
    }

}