using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks{

    public class GetBooksQuery{

        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<Book> Handle(){
            var bookList = _dbContext.Books.OrderBy(book => book.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
            return bookList;
        }
    }

    public class BooksViewModel{
        public string Title { get; set; }
         public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublisDate { get; set; }
       
    }

}