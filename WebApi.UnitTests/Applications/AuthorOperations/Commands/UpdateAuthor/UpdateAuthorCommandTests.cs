using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.DBOperations;
using WebApi.UnitTests.TestsSetup;
using Xunit;

namespace WebApi.UnitTests.Applications.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void UpdateAuthorCommand_ShouldReturnError_WhenAuthorNameAlreadyExist()
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context,_mapper);
            command.Model = new UpdateAuthorModel
            {
                FirstName = "Zikriye"
            };

            FluentActions.Invoking(()=> command.Handle())
                .Should().Throw<InvalidOperationException>();
        }
    }
}
