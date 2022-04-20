using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.BookOperations.UpdateBook;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void UpdateBookCommand_ShouldReturnError_WhenBookNotExists()
        {
            //arrange
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = 0;
            command.Model = new UpdateBookModel
            {
                Title = "new Title",
                GenreId = 2
            };

            //act & asserts

            FluentActions.Invoking(()=> command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book not found");
        }
    }
}
