using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.GenreOperations.Queries
{
    public class GetGenreDetailQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreDetailQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }


        [Fact]
        public void GetGenreDetailQuery_ShouldReturnError_WhenInputIsInvalid()
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            query.GenreId = 0;

            FluentActions.Invoking(()=> query.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Book genre is not found");
            
            
        }

        [Fact]
        public void GetGenreDetailQuery_ShouldReturnResult_WhenInputIsValid()
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            
            query.GenreId = 1;

            var result = query.Handle();
            (result.GetType()).Should().Be(typeof(GenreDetailViewModel));


        }
    }
}
