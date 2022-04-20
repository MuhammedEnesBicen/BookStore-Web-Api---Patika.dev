using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestsSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.AddRange(
                new Author() 
                {BirthDate=DateTime.Parse("1992,12,12"),
                    FirstName="Zikriye",
                    LastName="Ürkmez" },
                new Author()
                {
                    BirthDate = DateTime.Parse("560,12,12"),
                    FirstName = "Muhammed",
                    LastName = "Enes"
                }
                ,
                new Author()
                {
                    BirthDate = DateTime.Parse("560,12,12"),
                    FirstName = "Ahmed",
                    LastName = "Talha"
                });
        }
    }
}
