using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.BookOperations.DeleteBook;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {


        [Theory]
        [InlineData(-1)]
        [InlineData(0)]

        public void DeleteBookCommandValidator_ShouldReturnErrors_WhenIdIsInvalid(int bookId)
        {
            //Arrange
            DeleteBookCommand command = new DeleteBookCommand(null);
            command.BookId = bookId;

            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            //act
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
