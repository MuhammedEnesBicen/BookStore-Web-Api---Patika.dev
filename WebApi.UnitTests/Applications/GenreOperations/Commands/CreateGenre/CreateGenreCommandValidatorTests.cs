using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.GenreOperations.Commands
{
    public class CreateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {


        [Theory]
        [InlineData("asd")]
        [InlineData("    ")]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeGivenErrors
            (string title)
        {
            //arrange
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model = new CreateGenreModel()
            {
                Name = title,
            };
            //act
            var validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

        }



        [Fact]
        public void WhenValidInputsAreIsGiven_Validator_ShouldNotBeReturnErrors()
        {
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model = new CreateGenreModel()
            {
                Name="new Genre"
            };
            var validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);



        }

    }
}
