using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Fact]
        public void CreateAuthorCommand_ShouldReturnError_WhenAuthorAlreadyExist()
        {
            CreateAuthorCommand command = new CreateAuthorCommand(null, null);
            command.Model = new CreateAuthorModel()
            { FirstName = "asd", LastName = "dsa", BirthDate = DateTime.Parse("650,12,12") };
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();


            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
