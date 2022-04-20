using AutoMapper;
using FluentAssertions;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetails;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.AuthorOperations.queries
{
    public class GetAuthorDetailsQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorDetailsQueryTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void GetAuthorQuery_ShouldReturnError_WhenAuthorNotExist()
        {
            GetAuthorDetailsQuery query = new GetAuthorDetailsQuery(_context,_mapper);
            query.AuthorId = 13;
            FluentActions.Invoking(() => query.Handle())
                .Should().Throw<InvalidOperationException>();
        }
    }
}
