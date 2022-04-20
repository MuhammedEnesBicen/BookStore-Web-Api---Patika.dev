using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Fact]
        public void DeleteAuthorCommandValidator_ShouldReturnError_WhenAuthorNameAlreadyExist()
        {

            DeleteAuthorCommand command = new DeleteAuthorCommand(null);
            command.AuthorId = 0;
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();


            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}
