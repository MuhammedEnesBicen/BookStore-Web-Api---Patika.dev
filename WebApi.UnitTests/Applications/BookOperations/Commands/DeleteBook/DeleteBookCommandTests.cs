using FluentAssertions;
using System;
using WebApi.Application.BookOperations.DeleteBook;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void DeleteBookCommand_Should_Throw_When_No_Book_Exists()
        {
            //arrange
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = 13;

            //act  & assert
            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Book not found");

        }
    }
}
