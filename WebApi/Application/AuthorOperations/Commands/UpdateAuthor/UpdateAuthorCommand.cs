using AutoMapper;
using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        public UpdateAuthorModel Model { get; set; }

        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateAuthorCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.Id == AuthorId);
            if (author == null)
                throw new InvalidOperationException("there is no such an AUthor");
            
            author.BirthDate = ( Model.BirthDate) != default ? Model.BirthDate : author.BirthDate;
            author.FirstName =( Model.FirstName) != default ? Model.FirstName : author.FirstName;
            author.LastName =( Model.LastName) != default ? Model.LastName : author.LastName;  
            _context.Authors.Update(author);
            _context.SaveChanges();
        }
    }

    public class UpdateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
