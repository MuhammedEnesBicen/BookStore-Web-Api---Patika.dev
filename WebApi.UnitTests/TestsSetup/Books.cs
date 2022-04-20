using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestsSetup
{
    public static class Books
    {
            public static void AddBooks(this BookStoreDbContext context)
            {
            context.Books.AddRange(
                   new Book
                   {
                        //Id = 1,
                        Title = "Lean Startup",
                       GenreId = 1, //Personal Growth
                        PageCount = 200,
                       PublishDate = new DateTime(2001, 06, 12),
                   },
                   new Book
                   {
                        /*Id = 2*/
                       Title = "Herland",
                       GenreId = 2, //Science Fiction
                        PageCount = 250,
                       PublishDate = new DateTime(2002, 06, 12),
                   },
                    new Book
                    {
                         //Id = 3,
                         Title = "Dune",
                        GenreId = 2, //Science Fiction
                         PageCount = 250,
                        PublishDate = new DateTime(2002, 06, 12),
                    });
            
        }
    }
}
