using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetails;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.DBOperations;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext conetxt, IMapper mapper)
        {
            _context = conetxt;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var query = new GetAuthorDetailsQuery(_context, _mapper);
            query.AuthorId = id;
            GetAuthorDetailsQueryValidator validator = new GetAuthorDetailsQueryValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpDelete("id")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = id;
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }

        [HttpPut("id")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updateModel)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context, _mapper);
            command.AuthorId = id;
            command.Model = updateModel;
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] CreateAuthorModel createModel)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = createModel;

            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}
