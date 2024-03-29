using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBookDetail{
    public class GetBookDetailQuery{
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper){
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle(){
            var book = _dbContext.Books
            .Where(x => x.Id == BookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException("Kitap bulunamadı");
            BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book); //new BookDetailViewModel();
            return vm;
        }

        public class BookDetailViewModel{
            public string Title { get; set; }
            public string Genre { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}