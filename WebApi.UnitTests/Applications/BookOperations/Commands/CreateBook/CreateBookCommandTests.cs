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
    public class CreateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

            public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
            
        [Fact]
        public void WhenAlreadyExistsBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //Arrange (Hazırlık)
            var book = new Book { Title = "asd", PageCount = 100, PublishDate = new DateTime(1990, 01, 11), GenreId = 1 };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CreateBookModel { Title= book.Title };
            //act  & assert   (çalıştırma & doğrulama)
            FluentActions.Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Book already exists");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeCreated ()
        {
            //arrange
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            var model =  new CreateBookModel { Title = "Hobbit", PageCount = 100, PublishDate = new DateTime(1990, 01, 11), GenreId = 1 };
            command.Model = model;
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke();

            //assert
            var book = _context.Books.SingleOrDefault(x => x.Title == model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.GenreId.Should().Be(model.GenreId);
            book.PublishDate.Should().Be(model.PublishDate);
        }
    }
}
