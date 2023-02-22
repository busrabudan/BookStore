using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DBOperations
{

    public class DataGenerator{

        public static void Initialize(IServiceProvider serviceProvider){
           using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>())){
                if(context.Books.Any()){
                    return;
                }

                context.Books.AddRange(
                    new Book(){
                        Title = "The Hobbit",
                        GenreId = 1,
                        PageCount = 295,
                        PublisDate = new DateTime(1937, 9, 21)
                    },
                    new Book(){
                        Title = "The Lord of the Rings",
                        GenreId = 1,
                        PageCount = 1216,
                        PublisDate = new DateTime(1954, 7, 29)
                    },
                    new Book(){
                        Title = "The Silmarillion",
                        GenreId = 2,
                        PageCount = 429,
                        PublisDate = new DateTime(1977, 9, 15)
                    });
                
                context.SaveChanges();
            }
        }
    }
}