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
    public class DeleteAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void DeleteAuthorCommand_ShouldReturn_WhenAuthorNotExist()
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = 13;
            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>();
        }
    }
}
