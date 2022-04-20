using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.BookOperations.CreateBook;
using WebApi.DBOperations;
using WebApi.Entities;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.BookOperations.Commands
{
    public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {


        [Theory]
        [InlineData("Lord Of The Rings",0,0)]
        [InlineData("Lord Of The Rings", 0, 1)]
        [InlineData("", 0, 0)]
        [InlineData("", 100, 1)]
        [InlineData("", 0, 1)]
        [InlineData("Lor", 100, 1)]
        [InlineData("Lord", 1, 0)]


        public void WhenInvalidInputsAreGiven_Validator_ShouldBeGivenErrors
            (string title, int pageCount, int genreId)
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = title,
                PageCount = pageCount,GenreId = genreId,
                PublishDate= DateTime.Now.Date,
            };
            //act
            var validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);

            }

        [Fact]
        public void WhenDateTimeIsGreaterThenNowIsGiven_Validator_ShouldBeReturnErrors()
        {
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = "Lord Of The Rings",
                PageCount = 100,
                GenreId = 1,
                PublishDate = DateTime.Now.Date.AddDays(1),
            };
            var validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);



        }

        [Fact]
        public void WhenValidInputsAreIsGiven_Validator_ShouldNotBeReturnErrors()
        {
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = "Lord Of The Rings",
                PageCount = 100,
                GenreId = 1,
                PublishDate = DateTime.Now.Date,
            };
            var validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);



        }

    }
}
