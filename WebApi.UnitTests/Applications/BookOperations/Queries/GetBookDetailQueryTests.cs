using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.BookOperations.GetBookDetail;
using WebApi.Application.BookOperations.GetBooks;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.BookOperations.Queries
{
    public class GetBookDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetBookDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }


        [Fact]
        public void GetBookDetailQuery_ShouldReturnError_WhenInputIsInvalid()
        {
            GetBookDetailQuery query = new GetBookDetailQuery(_context, null);
            query.BookId = 0;

            FluentActions.Invoking(()=> query.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Book Not found");
            
            
        }

        [Fact]
        public void GetBookDetailQuery_ShouldReturnResult_WhenInputIsValid()
        {
            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
            
            query.BookId = 1;

            var result = query.Handle();
            (result.GetType()).Should().Be(typeof(BookDetailViewModel));


        }
    }
}
