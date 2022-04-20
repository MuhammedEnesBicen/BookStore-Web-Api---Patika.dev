using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorValidatorCommandTests : IClassFixture<CommonTestFixture>
    {

        [Fact]
        public void UpdateAuthorCommandValidator_ShouldReturnError_WhenAuthorNameAlreadyExist()
        {

            UpdateAuthorCommand command = new UpdateAuthorCommand(null, null);
                command.Model = new UpdateAuthorModel
                { FirstName = "asd", LastName = "dsa", BirthDate = DateTime.Parse("650,12,12") };
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();


                var result = validator.Validate(command);
                result.Errors.Count.Should().BeGreaterThan(0);
            
        }
    }
}
