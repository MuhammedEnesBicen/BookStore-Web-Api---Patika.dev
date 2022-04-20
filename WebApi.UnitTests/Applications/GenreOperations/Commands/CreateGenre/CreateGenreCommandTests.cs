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
    public class CreateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;


        public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;

        }

        [Fact]
        public void WhenAlreadyExistsGenreTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //Arrange
            var genre = new Genre { Name="noval"};
            _context.Genres.Add(genre);
            _context.SaveChanges();

            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = new CreateGenreModel {Name= "noval" };
            //act  & assert
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Book genre already exists");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeCreated()
        {
            //arrange
            CreateGenreCommand command = new CreateGenreCommand(_context);
            var model = new CreateGenreModel {Name="New Genre" };
            command.Model = model;
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var genre = _context.Genres.SingleOrDefault(x => x.Name==model.Name);
            genre.Should().NotBeNull();
            genre.Name.Should().Be(model.Name);

        }
    }
}
