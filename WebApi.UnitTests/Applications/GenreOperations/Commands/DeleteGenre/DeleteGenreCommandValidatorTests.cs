using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {


        [Theory]
        [InlineData(-1)]
        [InlineData(0)]

        public void DeleteGenreCommandValidator_ShouldReturnErrors_WhenIdIsInvalid(int GenreId)
        {
            //Arrange
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.GenreId = GenreId;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            //act
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
