using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.BookOperations.UpdateBook;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData(0, "", 0)]
        [InlineData(1, "asd", 1)]
        [InlineData(1, "asdf", 0)]
        [InlineData(0, "asdf", 1)]

        public void UpdateBookCommandValidator_ShouldREturnErrors_WhenInputsAreInvalid
            (int bookId, string title, int genreId)
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.BookId = bookId;
            command.Model = new UpdateBookModel
            {
                Title = title,
                GenreId = genreId


            };
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

    }
}
