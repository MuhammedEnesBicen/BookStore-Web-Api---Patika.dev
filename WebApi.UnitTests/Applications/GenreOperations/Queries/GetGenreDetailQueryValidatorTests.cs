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
    public class GetGenreDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {


        [Theory]
        [InlineData(-1)]
        [InlineData(0)]

        public void DeleteGenreCommandValidator_ShouldReturnErrors_WhenIdIsInvalid(int GenreId)
        {
            //Arrange
            GetGenreDetailQuery query = new GetGenreDetailQuery(null,null);
            query.GenreId = GenreId;

            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            //act
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);

        }
    }
}