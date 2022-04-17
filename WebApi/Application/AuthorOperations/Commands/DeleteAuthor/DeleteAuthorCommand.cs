using AutoMapper;
using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _context;
        

        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
            
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.Id == AuthorId);
            if (author == null)
                throw new InvalidOperationException("Author not found");
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
