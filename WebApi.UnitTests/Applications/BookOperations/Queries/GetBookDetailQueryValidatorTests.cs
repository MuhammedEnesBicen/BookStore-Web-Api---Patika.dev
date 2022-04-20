using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.BookOperations.DeleteBook;
using WebApi.Application.BookOperations.GetBookDetail;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.BookOperations.Queries

{
    public class GetBookDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {


        [Theory]
        [InlineData(-1)]
        [InlineData(0)]

        public void DeleteBookCommandValidator_ShouldReturnErrors_WhenIdIsInvalid(int bookId)
        {
            //Arrange
            GetBookDetailQuery query = new GetBookDetailQuery(null,null);
            query.BookId = bookId;

            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            //act
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}