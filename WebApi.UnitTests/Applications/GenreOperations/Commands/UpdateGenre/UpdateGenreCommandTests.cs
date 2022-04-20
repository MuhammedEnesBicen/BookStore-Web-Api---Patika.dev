using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public UpdateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void UpdateGenreCommand_ShouldReturnError_WhenGenreNotExists()
        {
            //arrange
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = 0;
            command.Model = new UpdateGenreModel
            {
                Name="new genre name"
            };

            //act & asserts

            FluentActions.Invoking(()=> command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Book genre is not found");
        }

        [Fact]
        public void UpdateGenreCommand_ShouldReturnError_WhenNewNameAlreadyExists()
        {
            //arrange
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = 1;
            command.Model = new UpdateGenreModel
            {
                Name = "Personal Growth"
            };

            //act & asserts

            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("a genre with this name already exist");
        }
    }
}
