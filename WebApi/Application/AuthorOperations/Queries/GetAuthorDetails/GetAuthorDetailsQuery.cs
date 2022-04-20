using AutoMapper;
using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetails
{
    public class GetAuthorDetailsQuery
    {
        public int AuthorId { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetAuthorDetailsQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailsViewModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author == null)
                throw new InvalidOperationException("Author not found");

            return _mapper.Map<AuthorDetailsViewModel>(author);
        }
    }
    public class AuthorDetailsViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirttDate { get; set; }

    }
}
