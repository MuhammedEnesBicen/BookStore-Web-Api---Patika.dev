using FluentAssertions;
using System;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public DeleteGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void DeleteGenreCommand_Should_Throw_When_No_Genre_Exists()
        {
            //arrange
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = 12;

            //act  & assert
            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Book genre is not found");

        }
    }
}
